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
    public partial class rKhachHangChanhViewModel : BaseViewModel<rKhachHangChanhDto, rKhachHangChanhDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rKhachHangChanhDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rKhachHangChanhDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaChanhFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _LaMacDinhFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rKhachHangChanhViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rKhachHangChanh_ID, nameof(rKhachHangChanhDataModel.ID), typeof(int));
            _MaChanhFilter = new HeaderComboBoxFilterModel(
                TextManager.rKhachHangChanh_MaChanh, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rKhachHangChanhDataModel.MaChanh),
                typeof(int),
                nameof(rChanhDataModel.DisplayText),
                nameof(rChanhDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaChanhAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rChanhView(), "rChanh", ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.Get()
            };
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.rKhachHangChanh_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rKhachHangChanhDataModel.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDataModel.DisplayText),
                nameof(rKhachHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get()
            };
            _LaMacDinhFilter = new HeaderCheckFilterModel(TextManager.rKhachHangChanh_LaMacDinh, nameof(rKhachHangChanhDataModel.LaMacDinh), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rKhachHangChanh_TenantID, nameof(rKhachHangChanhDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rKhachHangChanh_CreateTime, nameof(rKhachHangChanhDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rKhachHangChanh_LastUpdateTime, nameof(rKhachHangChanhDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaChanhFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_LaMacDinhFilter);
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
            ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rKhachHangChanhDataModel dataModel)
        {
            dataModel.MaChanhDataSource = ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.Get();
            dataModel.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rKhachHangChanhDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaChanhFilter.FilterValue != null)
            {
                dataModel.MaChanh = (int)_MaChanhFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dataModel.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_LaMacDinhFilter.FilterValue != null)
            {
                dataModel.LaMacDinh = (bool)_LaMacDinhFilter.FilterValue;
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
