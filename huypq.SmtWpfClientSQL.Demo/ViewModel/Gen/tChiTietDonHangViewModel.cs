using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tChiTietDonHangViewModel : BaseViewModel<tChiTietDonHangDto, tChiTietDonHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChiTietDonHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChiTietDonHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaDonHangFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _XongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietDonHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_ID, nameof(tChiTietDonHangDataModel.ID), typeof(int));
            _MaDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietDonHang_MaDonHang, nameof(tChiTietDonHangDataModel.MaDonHang), typeof(int), new View.tDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiTietDonHang_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiTietDonHangDataModel.MaMatHang),
                typeof(int),
                nameof(tMatHangDataModel.DisplayText),
                nameof(tMatHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get()
            };
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_SoLuong, nameof(tChiTietDonHangDataModel.SoLuong), typeof(int));
            _XongFilter = new HeaderCheckFilterModel(TextManager.tChiTietDonHang_Xong, nameof(tChiTietDonHangDataModel.Xong), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_TenantID, nameof(tChiTietDonHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_CreateTime, nameof(tChiTietDonHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_LastUpdateTime, nameof(tChiTietDonHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaDonHangFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_XongFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChiTietDonHangDataModel dataModel)
        {
            dataModel.MaMatHangDataSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChiTietDonHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaDonHangFilter.FilterValue != null)
            {
                dataModel.MaDonHang = (int)_MaDonHangFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dataModel.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dataModel.SoLuong = (int)_SoLuongFilter.FilterValue;
            }
            if (_XongFilter.FilterValue != null)
            {
                dataModel.Xong = (bool)_XongFilter.FilterValue;
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
