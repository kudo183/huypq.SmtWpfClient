using System.Collections.Generic;
using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using QueryBuilder;
using huypq.SmtShared.Constant;
using System.Linq;

namespace huypq.SmtWpfClient
{
    public sealed class ReferenceDataManager<T> where T : SmtIDto
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
        private long _lastUpdate;
        private bool _isLoaded = false;
        private const string LastUpdateTimePropertyName = nameof(SmtIDto.LastUpdateTime);

        public void SetOrderChecker(System.Func<T, T, bool> checker)
        {
            _datas.SetOrderChecker(checker);
        }

        public void SetWhereOptions(List<WhereExpression.IWhereOption> whereOptions)
        {
            if (whereOptions == null)
            {
                _whereOptions.Clear();
            }
            else
            {
                _whereOptions = whereOptions;
            }
        }

        private void Load()
        {
            var result = DataService.GetAll<T>(_whereOptions);
            _lastUpdate = result.LastUpdateTime;
            _datas.Reset(result.Items);

            _isLoaded = true;
        }

        public void Update()
        {
            if (_isLoaded == false)
            {
                Load();
                return;
            }

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

                var result = DataService.GetUpdate<T>(_whereOptions);
                _lastUpdate = result.LastUpdateTime;
                
                foreach (var item in result.Items)
                {
                    switch (item.State)
                    {
                        case DtoState.Add:
                            _datas.Add(item);
                            break;
                        case DtoState.Update:
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

        public ObservableCollectionEx<T> Get(bool forceReload = false)
        {
            if (forceReload == true)
            {
                Load();
            }
            else
            {
                Update();
            }
            return _datas;
        }

        public List<T> GetList(bool forceReload = false)
        {
            if (forceReload)
            {
                Load();
            }
            else
            {
                Update();
            }
            return _datas.ToList();
        }

        public T GetByID(int id)
        {
            return _datas.FindFirst(p => p.ID == id);
        }
    }
}
