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
    public partial class tTonKhoViewModel : BaseViewModel<tTonKhoDto, tTonKhoDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tTonKhoDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tTonKhoDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _SoLuongCuFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tTonKhoViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tTonKho_ID, nameof(tTonKhoDataModel.ID), typeof(int));
            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tTonKho_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tTonKhoDataModel.MaKhoHang),
                typeof(int),
                nameof(rKhoHangDataModel.DisplayText),
                nameof(rKhoHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get()
            };
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tTonKho_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tTonKhoDataModel.MaMatHang),
                typeof(int),
                nameof(tMatHangDataModel.DisplayText),
                nameof(tMatHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tTonKho_Ngay, nameof(tTonKhoDataModel.Ngay), typeof(System.DateTime));
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tTonKho_SoLuong, nameof(tTonKhoDataModel.SoLuong), typeof(int));
            _SoLuongCuFilter = new HeaderTextFilterModel(TextManager.tTonKho_SoLuongCu, nameof(tTonKhoDataModel.SoLuongCu), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tTonKho_TenantID, nameof(tTonKhoDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tTonKho_CreateTime, nameof(tTonKhoDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tTonKho_LastUpdateTime, nameof(tTonKhoDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_SoLuongCuFilter);
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
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tTonKhoDataModel dataModel)
        {
            dataModel.MaKhoHangDataSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get();
            dataModel.MaMatHangDataSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tTonKhoDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dataModel.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dataModel.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dataModel.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dataModel.SoLuong = (int)_SoLuongFilter.FilterValue;
            }
            if (_SoLuongCuFilter.FilterValue != null)
            {
                dataModel.SoLuongCu = (int)_SoLuongCuFilter.FilterValue;
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
