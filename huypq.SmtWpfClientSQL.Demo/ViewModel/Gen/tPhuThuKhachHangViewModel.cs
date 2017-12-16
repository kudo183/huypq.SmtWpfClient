using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tPhuThuKhachHangViewModel : BaseViewModel<tPhuThuKhachHangDto, tPhuThuKhachHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tPhuThuKhachHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tPhuThuKhachHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoTienFilter;
        HeaderFilterBaseModel _GhiChuFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tPhuThuKhachHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_ID, nameof(tPhuThuKhachHangDataModel.ID), typeof(int));
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tPhuThuKhachHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tPhuThuKhachHangDataModel.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDataModel.DisplayText),
                nameof(rKhachHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tPhuThuKhachHang_Ngay, nameof(tPhuThuKhachHangDataModel.Ngay), typeof(System.DateTime));
            _SoTienFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_SoTien, nameof(tPhuThuKhachHangDataModel.SoTien), typeof(int));
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_GhiChu, nameof(tPhuThuKhachHangDataModel.GhiChu), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_TenantID, nameof(tPhuThuKhachHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_CreateTime, nameof(tPhuThuKhachHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_LastUpdateTime, nameof(tPhuThuKhachHangDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoTienFilter);
            AddHeaderFilter(_GhiChuFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tPhuThuKhachHangDataModel dataModel)
        {
            dataModel.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tPhuThuKhachHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dataModel.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dataModel.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_SoTienFilter.FilterValue != null)
            {
                dataModel.SoTien = (int)_SoTienFilter.FilterValue;
            }
            if (_GhiChuFilter.FilterValue != null)
            {
                dataModel.GhiChu = (string)_GhiChuFilter.FilterValue;
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
