using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tChiTietToaHangViewModel : BaseViewModel<tChiTietToaHangDto, tChiTietToaHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChiTietToaHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChiTietToaHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaToaHangFilter;
        HeaderFilterBaseModel _MaChiTietDonHangFilter;
        HeaderFilterBaseModel _GiaTienFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietToaHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_ID, nameof(tChiTietToaHangDataModel.ID), typeof(int));
            _MaToaHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietToaHang_MaToaHang, nameof(tChiTietToaHangDataModel.MaToaHang), typeof(int), new View.tToaHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaChiTietDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietToaHang_MaChiTietDonHang, nameof(tChiTietToaHangDataModel.MaChiTietDonHang), typeof(int), new View.tChiTietDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _GiaTienFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_GiaTien, nameof(tChiTietToaHangDataModel.GiaTien), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_TenantID, nameof(tChiTietToaHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_CreateTime, nameof(tChiTietToaHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_LastUpdateTime, nameof(tChiTietToaHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaToaHangFilter);
            AddHeaderFilter(_MaChiTietDonHangFilter);
            AddHeaderFilter(_GiaTienFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChiTietToaHangDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChiTietToaHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaToaHangFilter.FilterValue != null)
            {
                dataModel.MaToaHang = (int)_MaToaHangFilter.FilterValue;
            }
            if (_MaChiTietDonHangFilter.FilterValue != null)
            {
                dataModel.MaChiTietDonHang = (int)_MaChiTietDonHangFilter.FilterValue;
            }
            if (_GiaTienFilter.FilterValue != null)
            {
                dataModel.GiaTien = (int)_GiaTienFilter.FilterValue;
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
