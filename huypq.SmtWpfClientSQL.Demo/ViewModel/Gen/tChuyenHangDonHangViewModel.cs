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
    public partial class tChuyenHangDonHangViewModel : BaseViewModel<tChuyenHangDonHangDto, tChuyenHangDonHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChuyenHangDonHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChuyenHangDonHangDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaChuyenHangFilter;
        HeaderFilterBaseModel _MaDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongTheoDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongThucTeFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;
        Dictionary<int, tChuyenHangDataModel> _MaChuyenHangs;
        Dictionary<int, tDonHangDataModel> _MaDonHangs;

        public tChuyenHangDonHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_ID, nameof(tChuyenHangDonHangDataModel.ID), typeof(int));
            _MaChuyenHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChuyenHangDonHang_MaChuyenHang, nameof(tChuyenHangDonHangDataModel.MaChuyenHang), typeof(int), new View.tChuyenHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChuyenHangDonHang_MaDonHang, nameof(tChuyenHangDonHangDataModel.MaDonHang), typeof(int), new View.tDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _TongSoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_TongSoLuongTheoDonHang, nameof(tChuyenHangDonHangDataModel.TongSoLuongTheoDonHang), typeof(int));
            _TongSoLuongThucTeFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_TongSoLuongThucTe, nameof(tChuyenHangDonHangDataModel.TongSoLuongThucTe), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_TenantID, nameof(tChuyenHangDonHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_CreateTime, nameof(tChuyenHangDonHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_LastUpdateTime, nameof(tChuyenHangDonHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaChuyenHangFilter);
            AddHeaderFilter(_MaDonHangFilter);
            AddHeaderFilter(_TongSoLuongTheoDonHangFilter);
            AddHeaderFilter(_TongSoLuongThucTeFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        protected override void AfterLoad()
        {
            _MaChuyenHangs = DataService.GetByListInt<tChuyenHangDto, tChuyenHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaChuyenHang).ToList()).ToDictionary(p => p.ID);
            _MaDonHangs = DataService.GetByListInt<tDonHangDto, tDonHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaDonHang).ToList()).ToDictionary(p => p.ID);
            foreach (var dataModel in Entities)
            {
                dataModel.MaChuyenHangNavigation = _MaChuyenHangs[dataModel.MaChuyenHang];
                dataModel.MaDonHangNavigation = _MaDonHangs[dataModel.MaDonHang];
            }

            AfterLoadPartial();
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChuyenHangDonHangDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChuyenHangDonHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaChuyenHangFilter.FilterValue != null)
            {
                dataModel.MaChuyenHang = (int)_MaChuyenHangFilter.FilterValue;
            }
            if (_MaDonHangFilter.FilterValue != null)
            {
                dataModel.MaDonHang = (int)_MaDonHangFilter.FilterValue;
            }
            if (_TongSoLuongTheoDonHangFilter.FilterValue != null)
            {
                dataModel.TongSoLuongTheoDonHang = (int)_TongSoLuongTheoDonHangFilter.FilterValue;
            }
            if (_TongSoLuongThucTeFilter.FilterValue != null)
            {
                dataModel.TongSoLuongThucTe = (int)_TongSoLuongThucTeFilter.FilterValue;
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
