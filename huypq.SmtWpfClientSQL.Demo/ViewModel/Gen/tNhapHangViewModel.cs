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
    public partial class tNhapHangViewModel : BaseViewModel<tNhapHangDto, tNhapHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tNhapHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tNhapHangDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaNhanVienFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _MaNhaCungCapFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tNhapHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tNhapHang_ID, nameof(tNhapHangDataModel.ID), typeof(int));
            _MaNhanVienFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapHang_MaNhanVien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapHangDataModel.MaNhanVien),
                typeof(int),
                nameof(rNhanVienDataModel.DisplayText),
                nameof(rNhanVienDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhanVienView(), "rNhanVien", ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.Get()
            };
            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapHang_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapHangDataModel.MaKhoHang),
                typeof(int),
                nameof(rKhoHangDataModel.DisplayText),
                nameof(rKhoHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get()
            };
            _MaNhaCungCapFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapHang_MaNhaCungCap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapHangDataModel.MaNhaCungCap),
                typeof(int),
                nameof(rNhaCungCapDataModel.DisplayText),
                nameof(rNhaCungCapDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNhaCungCapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhaCungCapView(), "rNhaCungCap", ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tNhapHang_Ngay, nameof(tNhapHangDataModel.Ngay), typeof(System.DateTime));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tNhapHang_TenantID, nameof(tNhapHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tNhapHang_CreateTime, nameof(tNhapHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tNhapHang_LastUpdateTime, nameof(tNhapHangDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaNhanVienFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_MaNhaCungCapFilter);
            AddHeaderFilter(_NgayFilter);
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
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tNhapHangDataModel dataModel)
        {
            dataModel.MaNhanVienDataSource = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.Get();
            dataModel.MaKhoHangDataSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get();
            dataModel.MaNhaCungCapDataSource = ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tNhapHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaNhanVienFilter.FilterValue != null)
            {
                dataModel.MaNhanVien = (int)_MaNhanVienFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dataModel.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_MaNhaCungCapFilter.FilterValue != null)
            {
                dataModel.MaNhaCungCap = (int)_MaNhaCungCapFilter.FilterValue;
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
