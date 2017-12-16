using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tChiTietChuyenHangDonHangViewModel : BaseViewModel<tChiTietChuyenHangDonHangDto, tChiTietChuyenHangDonHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChiTietChuyenHangDonHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChiTietChuyenHangDonHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaChuyenHangDonHangFilter;
        HeaderFilterBaseModel _MaChiTietDonHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _SoLuongTheoDonHangFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietChuyenHangDonHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_ID, nameof(tChiTietChuyenHangDonHangDataModel.ID), typeof(int));
            _MaChuyenHangDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietChuyenHangDonHang_MaChuyenHangDonHang, nameof(tChiTietChuyenHangDonHangDataModel.MaChuyenHangDonHang), typeof(int), new View.tChuyenHangDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaChiTietDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietChuyenHangDonHang_MaChiTietDonHang, nameof(tChiTietChuyenHangDonHangDataModel.MaChiTietDonHang), typeof(int), new View.tChiTietDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_SoLuong, nameof(tChiTietChuyenHangDonHangDataModel.SoLuong), typeof(int));
            _SoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_SoLuongTheoDonHang, nameof(tChiTietChuyenHangDonHangDataModel.SoLuongTheoDonHang), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_TenantID, nameof(tChiTietChuyenHangDonHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_CreateTime, nameof(tChiTietChuyenHangDonHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_LastUpdateTime, nameof(tChiTietChuyenHangDonHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaChuyenHangDonHangFilter);
            AddHeaderFilter(_MaChiTietDonHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_SoLuongTheoDonHangFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChiTietChuyenHangDonHangDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChiTietChuyenHangDonHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaChuyenHangDonHangFilter.FilterValue != null)
            {
                dataModel.MaChuyenHangDonHang = (int)_MaChuyenHangDonHangFilter.FilterValue;
            }
            if (_MaChiTietDonHangFilter.FilterValue != null)
            {
                dataModel.MaChiTietDonHang = (int)_MaChiTietDonHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dataModel.SoLuong = (int)_SoLuongFilter.FilterValue;
            }
            if (_SoLuongTheoDonHangFilter.FilterValue != null)
            {
                dataModel.SoLuongTheoDonHang = (int)_SoLuongTheoDonHangFilter.FilterValue;
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
