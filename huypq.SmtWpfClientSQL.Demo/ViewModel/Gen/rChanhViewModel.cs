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
    public partial class rChanhViewModel : BaseViewModel<rChanhDto, rChanhDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rChanhDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rChanhDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaBaiXeFilter;
        HeaderFilterBaseModel _TenChanhFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rChanhViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rChanh_ID, nameof(rChanhDataModel.ID), typeof(int));
            _MaBaiXeFilter = new HeaderComboBoxFilterModel(
                TextManager.rChanh_MaBaiXe, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rChanhDataModel.MaBaiXe),
                typeof(int),
                nameof(rBaiXeDataModel.DisplayText),
                nameof(rBaiXeDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaBaiXeAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rBaiXeView(), "rBaiXe", ReferenceDataManager<rBaiXeDto, rBaiXeDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rBaiXeDto, rBaiXeDataModel>.Instance.Get()
            };
            _TenChanhFilter = new HeaderTextFilterModel(TextManager.rChanh_TenChanh, nameof(rChanhDataModel.TenChanh), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rChanh_TenantID, nameof(rChanhDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rChanh_CreateTime, nameof(rChanhDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rChanh_LastUpdateTime, nameof(rChanhDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaBaiXeFilter);
            AddHeaderFilter(_TenChanhFilter);
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
            ReferenceDataManager<rBaiXeDto, rBaiXeDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rChanhDataModel dataModel)
        {
            dataModel.MaBaiXeDataSource = ReferenceDataManager<rBaiXeDto, rBaiXeDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rChanhDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaBaiXeFilter.FilterValue != null)
            {
                dataModel.MaBaiXe = (int)_MaBaiXeFilter.FilterValue;
            }
            if (_TenChanhFilter.FilterValue != null)
            {
                dataModel.TenChanh = (string)_TenChanhFilter.FilterValue;
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
