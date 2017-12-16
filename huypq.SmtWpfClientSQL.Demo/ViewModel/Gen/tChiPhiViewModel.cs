using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtShared;
using System.Linq;
using System.Collections.Generic;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tChiPhiViewModel : BaseViewModel<tChiPhiDto, tChiPhiDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChiPhiDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChiPhiDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaNhanVienGiaoHangFilter;
        HeaderFilterBaseModel _MaLoaiChiPhiFilter;
        HeaderFilterBaseModel _SoTienFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _GhiChuFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiPhiViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChiPhi_ID, nameof(tChiPhiDataModel.ID), typeof(int));
            _MaNhanVienGiaoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiPhi_MaNhanVienGiaoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiPhiDataModel.MaNhanVienGiaoHang),
                typeof(int),
                nameof(rNhanVienDataModel.DisplayText),
                nameof(rNhanVienDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienGiaoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhanVienView(), "rNhanVien", ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.Get()
            };
            _MaLoaiChiPhiFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiPhi_MaLoaiChiPhi, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiPhiDataModel.MaLoaiChiPhi),
                typeof(int),
                nameof(rLoaiChiPhiDataModel.DisplayText),
                nameof(rLoaiChiPhiDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaLoaiChiPhiAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rLoaiChiPhiView(), "rLoaiChiPhi", ReferenceDataManager<rLoaiChiPhiDto, rLoaiChiPhiDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rLoaiChiPhiDto, rLoaiChiPhiDataModel>.Instance.Get()
            };
            _SoTienFilter = new HeaderTextFilterModel(TextManager.tChiPhi_SoTien, nameof(tChiPhiDataModel.SoTien), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.tChiPhi_Ngay, nameof(tChiPhiDataModel.Ngay), typeof(System.DateTime));
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.tChiPhi_GhiChu, nameof(tChiPhiDataModel.GhiChu), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiPhi_TenantID, nameof(tChiPhiDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiPhi_CreateTime, nameof(tChiPhiDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiPhi_LastUpdateTime, nameof(tChiPhiDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaNhanVienGiaoHangFilter);
            AddHeaderFilter(_MaLoaiChiPhiFilter);
            AddHeaderFilter(_SoTienFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_GhiChuFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        protected override void AfterLoad()
        {

            AfterLoadPartial();
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rLoaiChiPhiDto, rLoaiChiPhiDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChiPhiDataModel dataModel)
        {
            dataModel.MaNhanVienGiaoHangDataSource = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.Get();
            dataModel.MaLoaiChiPhiDataSource = ReferenceDataManager<rLoaiChiPhiDto, rLoaiChiPhiDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChiPhiDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaNhanVienGiaoHangFilter.FilterValue != null)
            {
                dataModel.MaNhanVienGiaoHang = (int)_MaNhanVienGiaoHangFilter.FilterValue;
            }
            if (_MaLoaiChiPhiFilter.FilterValue != null)
            {
                dataModel.MaLoaiChiPhi = (int)_MaLoaiChiPhiFilter.FilterValue;
            }
            if (_SoTienFilter.FilterValue != null)
            {
                dataModel.SoTien = (int)_SoTienFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dataModel.Ngay = (System.DateTime)_NgayFilter.FilterValue;
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
