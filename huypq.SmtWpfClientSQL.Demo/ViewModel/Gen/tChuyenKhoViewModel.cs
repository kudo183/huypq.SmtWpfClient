using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tChuyenKhoViewModel : BaseViewModel<tChuyenKhoDto, tChuyenKhoDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChuyenKhoDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChuyenKhoDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaNhanVienFilter;
        HeaderFilterBaseModel _MaKhoHangXuatFilter;
        HeaderFilterBaseModel _MaKhoHangNhapFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChuyenKhoViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChuyenKho_ID, nameof(tChuyenKhoDataModel.ID), typeof(int));
            _MaNhanVienFilter = new HeaderComboBoxFilterModel(
                TextManager.tChuyenKho_MaNhanVien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChuyenKhoDataModel.MaNhanVien),
                typeof(int),
                nameof(rNhanVienDataModel.DisplayText),
                nameof(rNhanVienDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhanVienView(), "rNhanVien", ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.Get()
            };
            _MaKhoHangXuatFilter = new HeaderComboBoxFilterModel(
                TextManager.tChuyenKho_MaKhoHangXuat, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChuyenKhoDataModel.MaKhoHangXuat),
                typeof(int),
                nameof(rKhoHangDataModel.DisplayText),
                nameof(rKhoHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangXuatAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get()
            };
            _MaKhoHangNhapFilter = new HeaderComboBoxFilterModel(
                TextManager.tChuyenKho_MaKhoHangNhap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChuyenKhoDataModel.MaKhoHangNhap),
                typeof(int),
                nameof(rKhoHangDataModel.DisplayText),
                nameof(rKhoHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangNhapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tChuyenKho_Ngay, nameof(tChuyenKhoDataModel.Ngay), typeof(System.DateTime));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChuyenKho_TenantID, nameof(tChuyenKhoDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenKho_CreateTime, nameof(tChuyenKhoDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenKho_LastUpdateTime, nameof(tChuyenKhoDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaNhanVienFilter);
            AddHeaderFilter(_MaKhoHangXuatFilter);
            AddHeaderFilter(_MaKhoHangNhapFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChuyenKhoDataModel dataModel)
        {
            dataModel.MaNhanVienDataSource = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.Get();
            dataModel.MaKhoHangXuatDataSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get();
            dataModel.MaKhoHangNhapDataSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChuyenKhoDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaNhanVienFilter.FilterValue != null)
            {
                dataModel.MaNhanVien = (int)_MaNhanVienFilter.FilterValue;
            }
            if (_MaKhoHangXuatFilter.FilterValue != null)
            {
                dataModel.MaKhoHangXuat = (int)_MaKhoHangXuatFilter.FilterValue;
            }
            if (_MaKhoHangNhapFilter.FilterValue != null)
            {
                dataModel.MaKhoHangNhap = (int)_MaKhoHangNhapFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dataModel.Ngay = (System.DateTime)_NgayFilter.FilterValue;
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
