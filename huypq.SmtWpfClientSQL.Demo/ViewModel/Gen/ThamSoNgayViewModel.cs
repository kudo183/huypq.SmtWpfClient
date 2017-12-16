using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using huypq.SmtWpfClientSQL.Demo.DataModel;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.ViewModel
{
    public partial class ThamSoNgayViewModel : BaseViewModel<ThamSoNgayDto, ThamSoNgayDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(ThamSoNgayDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(ThamSoNgayDataModel dataModel);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenFilter;
        HeaderFilterBaseModel _GiaTriFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public ThamSoNgayViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_ID, nameof(ThamSoNgayDataModel.ID), typeof(int));
            _TenFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_Ten, nameof(ThamSoNgayDataModel.Ten), typeof(string));
            _GiaTriFilter = new HeaderDateFilterModel(TextManager.ThamSoNgay_GiaTri, nameof(ThamSoNgayDataModel.GiaTri), typeof(System.DateTime));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_TenantID, nameof(ThamSoNgayDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_CreateTime, nameof(ThamSoNgayDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_LastUpdateTime, nameof(ThamSoNgayDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenFilter);
            AddHeaderFilter(_GiaTriFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(ThamSoNgayDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(ThamSoNgayDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenFilter.FilterValue != null)
            {
                dataModel.Ten = (string)_TenFilter.FilterValue;
            }
            if (_GiaTriFilter.FilterValue != null)
            {
                dataModel.GiaTri = (System.DateTime)_GiaTriFilter.FilterValue;
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
