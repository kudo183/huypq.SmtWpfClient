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
    public partial class rNuocViewModel : BaseViewModel<rNuocDto, rNuocDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rNuocDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rNuocDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenNuocFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rNuocViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rNuoc_ID, nameof(rNuocDataModel.ID), typeof(int));
            _TenNuocFilter = new HeaderTextFilterModel(TextManager.rNuoc_TenNuoc, nameof(rNuocDataModel.TenNuoc), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rNuoc_TenantID, nameof(rNuocDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rNuoc_CreateTime, nameof(rNuocDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rNuoc_LastUpdateTime, nameof(rNuocDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenNuocFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        protected override void AfterLoad()
        {

            AfterLoadPartial();
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rNuocDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rNuocDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenNuocFilter.FilterValue != null)
            {
                dataModel.TenNuoc = (string)_TenNuocFilter.FilterValue;
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
