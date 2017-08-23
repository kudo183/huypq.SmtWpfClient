using System.Collections.Generic;
using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using huypq.QueryBuilder;
using huypq.SmtShared.Constant;
using huypq.wpf.Utils;

namespace huypq.SmtWpfClient
{
    public sealed class ReferenceDataManager<T> where T : IDto, IDisplayText
    {
        private static readonly ReferenceDataManager<T> _instance = new ReferenceDataManager<T>();

        public static ReferenceDataManager<T> Instance
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

        private readonly SortedObservableCollection<T> _datas = new SortedObservableCollection<T>();

        private List<WhereExpression.IWhereOption> _whereOptions = new List<WhereExpression.IWhereOption>();
        private System.Action<T> _processDtoBeforeAddToSortedCollectionAction;

        private long _lastUpdate;
        private bool _isLoaded = false;
        private const string LastUpdateTimePropertyName = nameof(IDto.LastUpdateTime);

        private ReferenceDataManager()
        {
            _datas.SetOrderChecker((p1, p2) => { return string.Compare(p1.DisplayText, p2.DisplayText) < 0; });
        }

        public void Init(System.Action<T> processDtoBeforeAddToSortedCollection, List<WhereExpression.IWhereOption> whereOptions = null, System.Func<T, T, bool> checker = null)
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
            var result = DataService.GetAll<T>(_whereOptions);
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

                var result = DataService.GetUpdate<T>(we);
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
                            _processDtoBeforeAddToSortedCollectionAction?.Invoke(item);
                            _datas.UpdateFirst(p => p.ID == item.ID, p => p.Update(item));
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

        public ObservableCollectionEx<T> Get()
        {
            if (_isLoaded == false)
            {
                Load();
            }
            return _datas;
        }

        public T GetByID(int id)
        {
            if (_isLoaded == false)
            {
                Load();
            }
            return _datas.FindFirst(p => p.ID == id);
        }
    }
}
