using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tChiTietNhapHangViewModel : BaseViewModel<tChiTietNhapHangDto, tChiTietNhapHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChiTietNhapHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChiTietNhapHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaNhapHangFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietNhapHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChiTietNhapHang_ID, nameof(tChiTietNhapHangDataModel.ID), typeof(int));
            _MaNhapHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietNhapHang_MaNhapHang, nameof(tChiTietNhapHangDataModel.MaNhapHang), typeof(int), new View.tNhapHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiTietNhapHang_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiTietNhapHangDataModel.MaMatHang),
                typeof(int),
                nameof(tMatHangDataModel.DisplayText),
                nameof(tMatHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get()
            };
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tChiTietNhapHang_SoLuong, nameof(tChiTietNhapHangDataModel.SoLuong), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietNhapHang_TenantID, nameof(tChiTietNhapHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietNhapHang_CreateTime, nameof(tChiTietNhapHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietNhapHang_LastUpdateTime, nameof(tChiTietNhapHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaNhapHangFilter);
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

        protected override void ProcessDataModelBeforeAddToEntities(tChiTietNhapHangDataModel dataModel)
        {
            dataModel.MaMatHangDataSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChiTietNhapHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaNhapHangFilter.FilterValue != null)
            {
                dataModel.MaNhapHang = (int)_MaNhapHangFilter.FilterValue;
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
