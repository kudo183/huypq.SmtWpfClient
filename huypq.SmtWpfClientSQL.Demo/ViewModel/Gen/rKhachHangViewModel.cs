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
    public partial class rKhachHangViewModel : BaseViewModel<rKhachHangDto, rKhachHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rKhachHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rKhachHangDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaDiaDiemFilter;
        HeaderFilterBaseModel _TenKhachHangFilter;
        HeaderFilterBaseModel _KhachRiengFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rKhachHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rKhachHang_ID, nameof(rKhachHangDataModel.ID), typeof(int));
            _MaDiaDiemFilter = new HeaderComboBoxFilterModel(
                TextManager.rKhachHang_MaDiaDiem, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rKhachHangDataModel.MaDiaDiem),
                typeof(int),
                nameof(rDiaDiemDataModel.DisplayText),
                nameof(rDiaDiemDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaDiaDiemAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rDiaDiemView(), "rDiaDiem", ReferenceDataManager<rDiaDiemDto, rDiaDiemDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rDiaDiemDto, rDiaDiemDataModel>.Instance.Get()
            };
            _TenKhachHangFilter = new HeaderTextFilterModel(TextManager.rKhachHang_TenKhachHang, nameof(rKhachHangDataModel.TenKhachHang), typeof(string));
            _KhachRiengFilter = new HeaderCheckFilterModel(TextManager.rKhachHang_KhachRieng, nameof(rKhachHangDataModel.KhachRieng), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rKhachHang_TenantID, nameof(rKhachHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rKhachHang_CreateTime, nameof(rKhachHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rKhachHang_LastUpdateTime, nameof(rKhachHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaDiaDiemFilter);
            AddHeaderFilter(_TenKhachHangFilter);
            AddHeaderFilter(_KhachRiengFilter);
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
            ReferenceDataManager<rDiaDiemDto, rDiaDiemDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rKhachHangDataModel dataModel)
        {
            dataModel.MaDiaDiemDataSource = ReferenceDataManager<rDiaDiemDto, rDiaDiemDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rKhachHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaDiaDiemFilter.FilterValue != null)
            {
                dataModel.MaDiaDiem = (int)_MaDiaDiemFilter.FilterValue;
            }
            if (_TenKhachHangFilter.FilterValue != null)
            {
                dataModel.TenKhachHang = (string)_TenKhachHangFilter.FilterValue;
            }
            if (_KhachRiengFilter.FilterValue != null)
            {
                dataModel.KhachRieng = (bool)_KhachRiengFilter.FilterValue;
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
