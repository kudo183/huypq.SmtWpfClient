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
    public partial class rKhoHangViewModel : BaseViewModel<rKhoHangDto, rKhoHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rKhoHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rKhoHangDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenKhoFilter;
        HeaderFilterBaseModel _TrangThaiFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rKhoHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rKhoHang_ID, nameof(rKhoHangDataModel.ID), typeof(int));
            _TenKhoFilter = new HeaderTextFilterModel(TextManager.rKhoHang_TenKho, nameof(rKhoHangDataModel.TenKho), typeof(string));
            _TrangThaiFilter = new HeaderCheckFilterModel(TextManager.rKhoHang_TrangThai, nameof(rKhoHangDataModel.TrangThai), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rKhoHang_TenantID, nameof(rKhoHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rKhoHang_CreateTime, nameof(rKhoHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rKhoHang_LastUpdateTime, nameof(rKhoHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenKhoFilter);
            AddHeaderFilter(_TrangThaiFilter);
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

        protected override void ProcessDataModelBeforeAddToEntities(rKhoHangDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rKhoHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenKhoFilter.FilterValue != null)
            {
                dataModel.TenKho = (string)_TenKhoFilter.FilterValue;
            }
            if (_TrangThaiFilter.FilterValue != null)
            {
                dataModel.TrangThai = (bool)_TrangThaiFilter.FilterValue;
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
