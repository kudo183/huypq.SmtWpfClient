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
    public partial class rNhanVienViewModel : BaseViewModel<rNhanVienDto, rNhanVienDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rNhanVienDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rNhanVienDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaPhuongTienFilter;
        HeaderFilterBaseModel _TenNhanVienFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rNhanVienViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rNhanVien_ID, nameof(rNhanVienDataModel.ID), typeof(int));
            _MaPhuongTienFilter = new HeaderComboBoxFilterModel(
                TextManager.rNhanVien_MaPhuongTien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rNhanVienDataModel.MaPhuongTien),
                typeof(int),
                nameof(rPhuongTienDataModel.DisplayText),
                nameof(rPhuongTienDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaPhuongTienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rPhuongTienView(), "rPhuongTien", ReferenceDataManager<rPhuongTienDto, rPhuongTienDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rPhuongTienDto, rPhuongTienDataModel>.Instance.Get()
            };
            _TenNhanVienFilter = new HeaderTextFilterModel(TextManager.rNhanVien_TenNhanVien, nameof(rNhanVienDataModel.TenNhanVien), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rNhanVien_TenantID, nameof(rNhanVienDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rNhanVien_CreateTime, nameof(rNhanVienDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rNhanVien_LastUpdateTime, nameof(rNhanVienDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaPhuongTienFilter);
            AddHeaderFilter(_TenNhanVienFilter);
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
            ReferenceDataManager<rPhuongTienDto, rPhuongTienDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rNhanVienDataModel dataModel)
        {
            dataModel.MaPhuongTienDataSource = ReferenceDataManager<rPhuongTienDto, rPhuongTienDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rNhanVienDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaPhuongTienFilter.FilterValue != null)
            {
                dataModel.MaPhuongTien = (int)_MaPhuongTienFilter.FilterValue;
            }
            if (_TenNhanVienFilter.FilterValue != null)
            {
                dataModel.TenNhanVien = (string)_TenNhanVienFilter.FilterValue;
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
