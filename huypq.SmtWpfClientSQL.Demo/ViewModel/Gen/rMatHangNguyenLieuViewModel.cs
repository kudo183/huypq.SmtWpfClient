using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class rMatHangNguyenLieuViewModel : BaseViewModel<rMatHangNguyenLieuDto, rMatHangNguyenLieuDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rMatHangNguyenLieuDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rMatHangNguyenLieuDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _MaNguyenLieuFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rMatHangNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rMatHangNguyenLieu_ID, nameof(rMatHangNguyenLieuDataModel.ID), typeof(int));
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.rMatHangNguyenLieu_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rMatHangNguyenLieuDataModel.MaMatHang),
                typeof(int),
                nameof(tMatHangDataModel.DisplayText),
                nameof(tMatHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get()
            };
            _MaNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.rMatHangNguyenLieu_MaNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rMatHangNguyenLieuDataModel.MaNguyenLieu),
                typeof(int),
                nameof(rNguyenLieuDataModel.DisplayText),
                nameof(rNguyenLieuDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNguyenLieuView(), "rNguyenLieu", ReferenceDataManager<rNguyenLieuDto, rNguyenLieuDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNguyenLieuDto, rNguyenLieuDataModel>.Instance.Get()
            };
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rMatHangNguyenLieu_TenantID, nameof(rMatHangNguyenLieuDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rMatHangNguyenLieu_CreateTime, nameof(rMatHangNguyenLieuDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rMatHangNguyenLieu_LastUpdateTime, nameof(rMatHangNguyenLieuDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_MaNguyenLieuFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNguyenLieuDto, rNguyenLieuDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rMatHangNguyenLieuDataModel dataModel)
        {
            dataModel.MaMatHangDataSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get();
            dataModel.MaNguyenLieuDataSource = ReferenceDataManager<rNguyenLieuDto, rNguyenLieuDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rMatHangNguyenLieuDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dataModel.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_MaNguyenLieuFilter.FilterValue != null)
            {
                dataModel.MaNguyenLieu = (int)_MaNguyenLieuFilter.FilterValue;
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
