using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid;
using System.Collections.Generic;

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

        private readonly ObservableCollectionEx<T> _datas
            = new ObservableCollectionEx<T>();

        private readonly List<T> _datasList = new List<T>();
        private readonly QueryBuilder.QueryExpression _qe = new QueryBuilder.QueryExpression() { PageIndex = -1 };

        public void SetOrderByOptions(List<QueryBuilder.OrderByExpression.OrderOption> orderOptions)
        {
            _qe.OrderOptions = orderOptions;
        }

        public void SetWhereOptions(List<QueryBuilder.WhereExpression.IWhereOption> whereOptions)
        {
            _qe.WhereOptions = whereOptions;
        }

        public void Load()
        {
            _datasList.Clear();
            _datasList.AddRange(DataService.Get<T>(_qe).Items);
            _datas.Reset(_datasList);
        }

        public ObservableCollectionEx<T> Get(bool forceReload = false)
        {
            if (forceReload)
            {
                Load();
            }
            return _datas;
        }

        public List<T> GetList(bool forceReload = false)
        {
            if (forceReload)
            {
                Load();
            }
            return _datasList;
        }

        public T GetByID(int id)
        {
            return _datasList.Find(p => p.ID == id);
        }
    }
}
