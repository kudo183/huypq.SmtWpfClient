using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class tToaHangViewModel : BaseViewModel<tToaHangDto, tToaHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tToaHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tToaHangDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tToaHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tToaHang_ID, nameof(tToaHangDataModel.ID), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.tToaHang_Ngay, nameof(tToaHangDataModel.Ngay), typeof(System.DateTime));
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tToaHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tToaHangDataModel.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDataModel.DisplayText),
                nameof(rKhachHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get()
            };
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tToaHang_TenantID, nameof(tToaHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tToaHang_CreateTime, nameof(tToaHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tToaHang_LastUpdateTime, nameof(tToaHangDataModel.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tToaHangDataModel dataModel)
        {
            dataModel.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tToaHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dataModel.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dataModel.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
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
