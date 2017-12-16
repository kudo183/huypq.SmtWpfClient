using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class rLoaiNguyenLieuViewModel : BaseViewModel<rLoaiNguyenLieuDto, rLoaiNguyenLieuDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rLoaiNguyenLieuDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rLoaiNguyenLieuDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenLoaiFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rLoaiNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_ID, nameof(rLoaiNguyenLieuDataModel.ID), typeof(int));
            _TenLoaiFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_TenLoai, nameof(rLoaiNguyenLieuDataModel.TenLoai), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_TenantID, nameof(rLoaiNguyenLieuDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_CreateTime, nameof(rLoaiNguyenLieuDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_LastUpdateTime, nameof(rLoaiNguyenLieuDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenLoaiFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rLoaiNguyenLieuDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rLoaiNguyenLieuDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenLoaiFilter.FilterValue != null)
            {
                dataModel.TenLoai = (string)_TenLoaiFilter.FilterValue;
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
