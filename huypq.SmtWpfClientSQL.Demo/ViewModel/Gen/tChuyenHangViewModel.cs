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
    public partial class tChuyenHangViewModel : BaseViewModel<tChuyenHangDto, tChuyenHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChuyenHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChuyenHangDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaNhanVienGiaoHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _GioFilter;
        HeaderFilterBaseModel _TongDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongTheoDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongThucTeFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChuyenHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_ID, nameof(tChuyenHangDataModel.ID), typeof(int));
            _MaNhanVienGiaoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChuyenHang_MaNhanVienGiaoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChuyenHangDataModel.MaNhanVienGiaoHang),
                typeof(int),
                nameof(rNhanVienDataModel.DisplayText),
                nameof(rNhanVienDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienGiaoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhanVienView(), "rNhanVien", ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tChuyenHang_Ngay, nameof(tChuyenHangDataModel.Ngay), typeof(System.DateTime));
            _GioFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_Gio, nameof(tChuyenHangDataModel.Gio), typeof(System.TimeSpan?));
            _TongDonHangFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_TongDonHang, nameof(tChuyenHangDataModel.TongDonHang), typeof(int));
            _TongSoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_TongSoLuongTheoDonHang, nameof(tChuyenHangDataModel.TongSoLuongTheoDonHang), typeof(int));
            _TongSoLuongThucTeFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_TongSoLuongThucTe, nameof(tChuyenHangDataModel.TongSoLuongThucTe), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_TenantID, nameof(tChuyenHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_CreateTime, nameof(tChuyenHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_LastUpdateTime, nameof(tChuyenHangDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaNhanVienGiaoHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_GioFilter);
            AddHeaderFilter(_TongDonHangFilter);
            AddHeaderFilter(_TongSoLuongTheoDonHangFilter);
            AddHeaderFilter(_TongSoLuongThucTeFilter);
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

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChuyenHangDataModel dataModel)
        {
            dataModel.MaNhanVienGiaoHangDataSource = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChuyenHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaNhanVienGiaoHangFilter.FilterValue != null)
            {
                dataModel.MaNhanVienGiaoHang = (int)_MaNhanVienGiaoHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dataModel.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_GioFilter.FilterValue != null)
            {
                dataModel.Gio = (System.TimeSpan?)_GioFilter.FilterValue;
            }
            if (_TongDonHangFilter.FilterValue != null)
            {
                dataModel.TongDonHang = (int)_TongDonHangFilter.FilterValue;
            }
            if (_TongSoLuongTheoDonHangFilter.FilterValue != null)
            {
                dataModel.TongSoLuongTheoDonHang = (int)_TongSoLuongTheoDonHangFilter.FilterValue;
            }
            if (_TongSoLuongThucTeFilter.FilterValue != null)
            {
                dataModel.TongSoLuongThucTe = (int)_TongSoLuongThucTeFilter.FilterValue;
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
