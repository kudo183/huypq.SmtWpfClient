using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class rNguyenLieuViewModel : BaseViewModel<rNguyenLieuDto, rNguyenLieuDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rNguyenLieuDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rNguyenLieuDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaLoaiNguyenLieuFilter;
        HeaderFilterBaseModel _DuongKinhFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_ID, nameof(rNguyenLieuDataModel.ID), typeof(int));
            _MaLoaiNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.rNguyenLieu_MaLoaiNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rNguyenLieuDataModel.MaLoaiNguyenLieu),
                typeof(int),
                nameof(rLoaiNguyenLieuDataModel.DisplayText),
                nameof(rLoaiNguyenLieuDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaLoaiNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rLoaiNguyenLieuView(), "rLoaiNguyenLieu", ReferenceDataManager<rLoaiNguyenLieuDto, rLoaiNguyenLieuDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rLoaiNguyenLieuDto, rLoaiNguyenLieuDataModel>.Instance.Get()
            };
            _DuongKinhFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_DuongKinh, nameof(rNguyenLieuDataModel.DuongKinh), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_TenantID, nameof(rNguyenLieuDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_CreateTime, nameof(rNguyenLieuDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_LastUpdateTime, nameof(rNguyenLieuDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaLoaiNguyenLieuFilter);
            AddHeaderFilter(_DuongKinhFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rLoaiNguyenLieuDto, rLoaiNguyenLieuDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rNguyenLieuDataModel dataModel)
        {
            dataModel.MaLoaiNguyenLieuDataSource = ReferenceDataManager<rLoaiNguyenLieuDto, rLoaiNguyenLieuDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rNguyenLieuDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaLoaiNguyenLieuFilter.FilterValue != null)
            {
                dataModel.MaLoaiNguyenLieu = (int)_MaLoaiNguyenLieuFilter.FilterValue;
            }
            if (_DuongKinhFilter.FilterValue != null)
            {
                dataModel.DuongKinh = (int)_DuongKinhFilter.FilterValue;
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
