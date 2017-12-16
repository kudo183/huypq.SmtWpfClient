using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class rDiaDiemViewModel : BaseViewModel<rDiaDiemDto, rDiaDiemDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rDiaDiemDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rDiaDiemDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaNuocFilter;
        HeaderFilterBaseModel _TinhFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rDiaDiemViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_ID, nameof(rDiaDiemDataModel.ID), typeof(int));
            _MaNuocFilter = new HeaderComboBoxFilterModel(
                TextManager.rDiaDiem_MaNuoc, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rDiaDiemDataModel.MaNuoc),
                typeof(int),
                nameof(rNuocDataModel.DisplayText),
                nameof(rNuocDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaNuocAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNuocView(), "rNuoc", ReferenceDataManager<rNuocDto, rNuocDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNuocDto, rNuocDataModel>.Instance.Get()
            };
            _TinhFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_Tinh, nameof(rDiaDiemDataModel.Tinh), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_TenantID, nameof(rDiaDiemDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_CreateTime, nameof(rDiaDiemDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_LastUpdateTime, nameof(rDiaDiemDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaNuocFilter);
            AddHeaderFilter(_TinhFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNuocDto, rNuocDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rDiaDiemDataModel dataModel)
        {
            dataModel.MaNuocDataSource = ReferenceDataManager<rNuocDto, rNuocDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rDiaDiemDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaNuocFilter.FilterValue != null)
            {
                dataModel.MaNuoc = (int)_MaNuocFilter.FilterValue;
            }
            if (_TinhFilter.FilterValue != null)
            {
                dataModel.Tinh = (string)_TinhFilter.FilterValue;
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
