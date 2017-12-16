using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class rNhaCungCapViewModel : BaseViewModel<rNhaCungCapDto, rNhaCungCapDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rNhaCungCapDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rNhaCungCapDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenNhaCungCapFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rNhaCungCapViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_ID, nameof(rNhaCungCapDataModel.ID), typeof(int));
            _TenNhaCungCapFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_TenNhaCungCap, nameof(rNhaCungCapDataModel.TenNhaCungCap), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_TenantID, nameof(rNhaCungCapDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_CreateTime, nameof(rNhaCungCapDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_LastUpdateTime, nameof(rNhaCungCapDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenNhaCungCapFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rNhaCungCapDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rNhaCungCapDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenNhaCungCapFilter.FilterValue != null)
            {
                dataModel.TenNhaCungCap = (string)_TenNhaCungCapFilter.FilterValue;
            }
            if (_TenantIDFilter.FilterValue != null)
            {
                dataModel.TenantID = (int)_TenantIDFilter.FilterValue;
            }
            if (_CreateTimeFilter.FilterValue != null)
            {
                dataModel.CreateTime = (long)_CreateTimeFilter.FilterValue;
            }
            if (_LastUpdateTimeFilter.FilterValue != null)
            {
                dataModel.LastUpdateTime = (long)_LastUpdateTimeFilter.FilterValue;
            }

            ProcessNewAddedDataModelPartial(dataModel);
            ProcessDataModelBeforeAddToEntities(dataModel);
        }
    }
}
