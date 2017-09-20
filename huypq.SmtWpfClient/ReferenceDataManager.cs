using System.Collections.Generic;
using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using huypq.QueryBuilder;
using huypq.SmtShared.Constant;
using huypq.wpf.Utils;

namespace huypq.SmtWpfClient
{
    public sealed class ReferenceDataManager<T,T1> where T : class, IDto, new() where T1 : class, IDataModel<T>, new()
    {
        private static readonly ReferenceDataManager<T,T1> _instance = new ReferenceDataManager<T, T1>();

        public static ReferenceDataManager<T, T1> Instance
        {
            get { return _instance; }
        }

        private IDataService _dataService;
        public IDataService DataService
        {
            get
            {
                if (_dataService == null)
                {
                    _dataService = ServiceLocator.Get<IDataService>();
                }

                return _dataService;
            }
            private set { }
        }

        private readonly SortedObservableCollection<T1> _datas = new SortedObservableCollection<T1>();

        private List<WhereExpression.IWhereOption> _whereOptions = new List<WhereExpression.IWhereOption>();
        private System.Action<T1> _processDtoBeforeAddToSortedCollectionAction;

        private long _lastUpdate;
        private bool _isLoaded = false;
        private const string LastUpdateTimePropertyName = nameof(IDto.LastUpdateTime);

        private ReferenceDataManager()
        {
            _datas.SetOrderChecker((p1, p2) => { return string.Compare(p1.DisplayText, p2.DisplayText) < 0; });
        }

        public void Init(System.Action<T1> processDtoBeforeAddToSortedCollection, List<WhereExpression.IWhereOption> whereOptions = null, System.Func<T1, T1, bool> checker = null)
        {
            _processDtoBeforeAddToSortedCollectionAction = processDtoBeforeAddToSortedCollection;
            if (whereOptions != null)
            {
                _whereOptions = whereOptions;
            }
            if (checker != null)
            {
                _datas.SetOrderChecker(checker);
            }
        }

        private void Load()
        {
            var result = DataService.GetAll<T, T1>(_whereOptions);
            _lastUpdate = result.LastUpdateTime;

            if (_processDtoBeforeAddToSortedCollectionAction != null)
            {
                foreach (var item in result.Items)
                {
                    _processDtoBeforeAddToSortedCollectionAction(item);
                }
            }
            _datas.Reset(result.Items);

            _isLoaded = true;
        }

        private void Update()
        {
            try
            {
                var we = new List<WhereExpression.IWhereOption>();

                foreach (var w in _whereOptions)
                {
                    if (w.PropertyPath != LastUpdateTimePropertyName)
                    {
                        we.Add(w);
                    }
                }
                we.Add(new WhereExpression.WhereOptionLong()
                {
                    Predicate = WhereExpression.GreaterThan,
                    PropertyPath = LastUpdateTimePropertyName,
                    Value = _lastUpdate
                });

                var result = DataService.GetUpdate<T, T1>(we);
                _lastUpdate = result.LastUpdateTime;

                foreach (var item in result.Items)
                {
                    switch (item.State)
                    {
                        case DtoState.Add:
                            _processDtoBeforeAddToSortedCollectionAction?.Invoke(item);
                            _datas.Add(item);
                            break;
                        case DtoState.Update:
                            _datas.UpdateFirst(p => p.ID == item.ID,
                                p =>
                                {
                                    p.Update(item);
                                    _processDtoBeforeAddToSortedCollectionAction?.Invoke(p);
                                });
                            break;
                        case DtoState.Delete:
                            _datas.RemoveFirst(p => p.ID == item.ID);
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Load();
            }
        }

        public void LoadOrUpdate()
        {
            if (_isLoaded == false)
            {
                Load();
            }
            else
            {
                Update();
            }
        }

        public ObservableCollectionEx<T1> Get()
        {
            if (_isLoaded == false)
            {
                Load();
            }
            return _datas;
        }

        public T1 GetByID(int id)
        {
            if (_isLoaded == false)
            {
                Load();
            }
            return _datas.FindFirst(p => p.ID == id);
        }
    }
}
