using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tChiTietChuyenKhoViewModel : BaseViewModel<tChiTietChuyenKhoDto, tChiTietChuyenKhoDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChiTietChuyenKhoDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChiTietChuyenKhoDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaChuyenKhoFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietChuyenKhoViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_ID, nameof(tChiTietChuyenKhoDataModel.ID), typeof(int));
            _MaChuyenKhoFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietChuyenKho_MaChuyenKho, nameof(tChiTietChuyenKhoDataModel.MaChuyenKho), typeof(int), new View.tChuyenKhoView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiTietChuyenKho_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiTietChuyenKhoDataModel.MaMatHang),
                typeof(int),
                nameof(tMatHangDataModel.DisplayText),
                nameof(tMatHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get()
            };
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_SoLuong, nameof(tChiTietChuyenKhoDataModel.SoLuong), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_TenantID, nameof(tChiTietChuyenKhoDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_CreateTime, nameof(tChiTietChuyenKhoDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_LastUpdateTime, nameof(tChiTietChuyenKhoDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaChuyenKhoFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChiTietChuyenKhoDataModel dataModel)
        {
            dataModel.MaMatHangDataSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChiTietChuyenKhoDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaChuyenKhoFilter.FilterValue != null)
            {
                dataModel.MaChuyenKho = (int)_MaChuyenKhoFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dataModel.MaMatHang = (int)_MaMatHangFilter.FilterValue;
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
