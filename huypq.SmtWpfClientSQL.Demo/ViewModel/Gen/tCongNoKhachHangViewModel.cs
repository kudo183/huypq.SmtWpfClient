using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tCongNoKhachHangViewModel : BaseViewModel<tCongNoKhachHangDto, tCongNoKhachHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tCongNoKhachHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tCongNoKhachHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoTienFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tCongNoKhachHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tCongNoKhachHang_ID, nameof(tCongNoKhachHangDataModel.ID), typeof(int));
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tCongNoKhachHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tCongNoKhachHangDataModel.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDataModel.DisplayText),
                nameof(rKhachHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tCongNoKhachHang_Ngay, nameof(tCongNoKhachHangDataModel.Ngay), typeof(System.DateTime));
            _SoTienFilter = new HeaderTextFilterModel(TextManager.tCongNoKhachHang_SoTien, nameof(tCongNoKhachHangDataModel.SoTien), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tCongNoKhachHang_TenantID, nameof(tCongNoKhachHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tCongNoKhachHang_CreateTime, nameof(tCongNoKhachHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tCongNoKhachHang_LastUpdateTime, nameof(tCongNoKhachHangDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoTienFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tCongNoKhachHangDataModel dataModel)
        {
            dataModel.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tCongNoKhachHangDataModel dataModel)
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
