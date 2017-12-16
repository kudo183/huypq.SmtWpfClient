using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tGiamTruKhachHangViewModel : BaseViewModel<tGiamTruKhachHangDto, tGiamTruKhachHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tGiamTruKhachHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tGiamTruKhachHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoTienFilter;
        HeaderFilterBaseModel _GhiChuFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tGiamTruKhachHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tGiamTruKhachHang_ID, nameof(tGiamTruKhachHangDataModel.ID), typeof(int));
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tGiamTruKhachHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tGiamTruKhachHangDataModel.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDataModel.DisplayText),
                nameof(rKhachHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tGiamTruKhachHang_Ngay, nameof(tGiamTruKhachHangDataModel.Ngay), typeof(System.DateTime));
            _SoTienFilter = new HeaderTextFilterModel(TextManager.tGiamTruKhachHang_SoTien, nameof(tGiamTruKhachHangDataModel.SoTien), typeof(int));
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.tGiamTruKhachHang_GhiChu, nameof(tGiamTruKhachHangDataModel.GhiChu), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tGiamTruKhachHang_TenantID, nameof(tGiamTruKhachHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tGiamTruKhachHang_CreateTime, nameof(tGiamTruKhachHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tGiamTruKhachHang_LastUpdateTime, nameof(tGiamTruKhachHangDataModel.LastUpdateTime), typeof(long));

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

        protected override void ProcessDataModelBeforeAddToEntities(tGiamTruKhachHangDataModel dataModel)
        {
            dataModel.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tGiamTruKhachHangDataModel dataModel)
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
