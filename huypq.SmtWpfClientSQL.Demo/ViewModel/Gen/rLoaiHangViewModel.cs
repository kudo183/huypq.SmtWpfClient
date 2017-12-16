using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class rLoaiHangViewModel : BaseViewModel<rLoaiHangDto, rLoaiHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rLoaiHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rLoaiHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenLoaiFilter;
        HeaderFilterBaseModel _HangNhaLamFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rLoaiHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_ID, nameof(rLoaiHangDataModel.ID), typeof(int));
            _TenLoaiFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_TenLoai, nameof(rLoaiHangDataModel.TenLoai), typeof(string));
            _HangNhaLamFilter = new HeaderCheckFilterModel(TextManager.rLoaiHang_HangNhaLam, nameof(rLoaiHangDataModel.HangNhaLam), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_TenantID, nameof(rLoaiHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_CreateTime, nameof(rLoaiHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_LastUpdateTime, nameof(rLoaiHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenLoaiFilter);
            AddHeaderFilter(_HangNhaLamFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rLoaiHangDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rLoaiHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenLoaiFilter.FilterValue != null)
            {
                dataModel.TenLoai = (string)_TenLoaiFilter.FilterValue;
            }
            if (_HangNhaLamFilter.FilterValue != null)
            {
                dataModel.HangNhaLam = (bool)_HangNhaLamFilter.FilterValue;
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
