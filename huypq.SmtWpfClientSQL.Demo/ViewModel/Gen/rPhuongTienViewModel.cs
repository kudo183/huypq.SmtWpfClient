using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class rPhuongTienViewModel : BaseViewModel<rPhuongTienDto, rPhuongTienDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rPhuongTienDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rPhuongTienDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenPhuongTienFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rPhuongTienViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_ID, nameof(rPhuongTienDataModel.ID), typeof(int));
            _TenPhuongTienFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_TenPhuongTien, nameof(rPhuongTienDataModel.TenPhuongTien), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_TenantID, nameof(rPhuongTienDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_CreateTime, nameof(rPhuongTienDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_LastUpdateTime, nameof(rPhuongTienDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenPhuongTienFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rPhuongTienDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rPhuongTienDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenPhuongTienFilter.FilterValue != null)
            {
                dataModel.TenPhuongTien = (string)_TenPhuongTienFilter.FilterValue;
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
