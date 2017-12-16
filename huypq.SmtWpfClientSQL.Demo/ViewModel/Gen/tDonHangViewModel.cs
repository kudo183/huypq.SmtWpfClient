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
    public partial class tDonHangViewModel : BaseViewModel<tDonHangDto, tDonHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tDonHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tDonHangDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _MaChanhFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _XongFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _TongSoLuongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tDonHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tDonHang_ID, nameof(tDonHangDataModel.ID), typeof(int));
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tDonHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tDonHangDataModel.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDataModel.DisplayText),
                nameof(rKhachHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get()
            };
            _MaChanhFilter = new HeaderComboBoxFilterModel(
                TextManager.tDonHang_MaChanh, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tDonHangDataModel.MaChanh),
                typeof(int?),
                nameof(rChanhDataModel.DisplayText),
                nameof(rChanhDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaChanhAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rChanhView(), "rChanh", ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tDonHang_Ngay, nameof(tDonHangDataModel.Ngay), typeof(System.DateTime));
            _XongFilter = new HeaderCheckFilterModel(TextManager.tDonHang_Xong, nameof(tDonHangDataModel.Xong), typeof(bool));
            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tDonHang_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tDonHangDataModel.MaKhoHang),
                typeof(int),
                nameof(rKhoHangDataModel.DisplayText),
                nameof(rKhoHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get()
            };
            _TongSoLuongFilter = new HeaderTextFilterModel(TextManager.tDonHang_TongSoLuong, nameof(tDonHangDataModel.TongSoLuong), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tDonHang_TenantID, nameof(tDonHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tDonHang_CreateTime, nameof(tDonHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tDonHang_LastUpdateTime, nameof(tDonHangDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_MaChanhFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_XongFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_TongSoLuongFilter);
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
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tDonHangDataModel dataModel)
        {
            dataModel.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get();
            dataModel.MaChanhDataSource = ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.Get();
            dataModel.MaKhoHangDataSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tDonHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dataModel.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_MaChanhFilter.FilterValue != null)
            {
                dataModel.MaChanh = (int?)_MaChanhFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dataModel.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_XongFilter.FilterValue != null)
            {
                dataModel.Xong = (bool)_XongFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dataModel.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_TongSoLuongFilter.FilterValue != null)
            {
                dataModel.TongSoLuong = (int)_TongSoLuongFilter.FilterValue;
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
