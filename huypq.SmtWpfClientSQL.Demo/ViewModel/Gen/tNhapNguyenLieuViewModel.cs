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
    public partial class tNhapNguyenLieuViewModel : BaseViewModel<tNhapNguyenLieuDto, tNhapNguyenLieuDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tNhapNguyenLieuDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tNhapNguyenLieuDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _MaNguyenLieuFilter;
        HeaderFilterBaseModel _MaNhaCungCapFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tNhapNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_ID, nameof(tNhapNguyenLieuDataModel.ID), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.tNhapNguyenLieu_Ngay, nameof(tNhapNguyenLieuDataModel.Ngay), typeof(System.DateTime));
            _MaNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapNguyenLieu_MaNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapNguyenLieuDataModel.MaNguyenLieu),
                typeof(int),
                nameof(rNguyenLieuDataModel.DisplayText),
                nameof(rNguyenLieuDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNguyenLieuView(), "rNguyenLieu", ReferenceDataManager<rNguyenLieuDto, rNguyenLieuDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNguyenLieuDto, rNguyenLieuDataModel>.Instance.Get()
            };
            _MaNhaCungCapFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapNguyenLieu_MaNhaCungCap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapNguyenLieuDataModel.MaNhaCungCap),
                typeof(int),
                nameof(rNhaCungCapDataModel.DisplayText),
                nameof(rNhaCungCapDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNhaCungCapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhaCungCapView(), "rNhaCungCap", ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.Get()
            };
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_SoLuong, nameof(tNhapNguyenLieuDataModel.SoLuong), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_TenantID, nameof(tNhapNguyenLieuDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_CreateTime, nameof(tNhapNguyenLieuDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_LastUpdateTime, nameof(tNhapNguyenLieuDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_MaNguyenLieuFilter);
            AddHeaderFilter(_MaNhaCungCapFilter);
            AddHeaderFilter(_SoLuongFilter);
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
            ReferenceDataManager<rNguyenLieuDto, rNguyenLieuDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tNhapNguyenLieuDataModel dataModel)
        {
            dataModel.MaNguyenLieuDataSource = ReferenceDataManager<rNguyenLieuDto, rNguyenLieuDataModel>.Instance.Get();
            dataModel.MaNhaCungCapDataSource = ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tNhapNguyenLieuDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dataModel.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_MaNguyenLieuFilter.FilterValue != null)
            {
                dataModel.MaNguyenLieu = (int)_MaNguyenLieuFilter.FilterValue;
            }
            if (_MaNhaCungCapFilter.FilterValue != null)
            {
                dataModel.MaNhaCungCap = (int)_MaNhaCungCapFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dataModel.SoLuong = (int)_SoLuongFilter.FilterValue;
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
