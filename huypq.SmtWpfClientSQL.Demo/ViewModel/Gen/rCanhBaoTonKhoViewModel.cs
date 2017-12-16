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
    public partial class rCanhBaoTonKhoViewModel : BaseViewModel<rCanhBaoTonKhoDto, rCanhBaoTonKhoDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(rCanhBaoTonKhoDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(rCanhBaoTonKhoDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _TonCaoNhatFilter;
        HeaderFilterBaseModel _TonThapNhatFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rCanhBaoTonKhoViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_ID, nameof(rCanhBaoTonKhoDataModel.ID), typeof(int));
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.rCanhBaoTonKho_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rCanhBaoTonKhoDataModel.MaMatHang),
                typeof(int),
                nameof(tMatHangDataModel.DisplayText),
                nameof(tMatHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get()
            };
            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.rCanhBaoTonKho_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rCanhBaoTonKhoDataModel.MaKhoHang),
                typeof(int),
                nameof(rKhoHangDataModel.DisplayText),
                nameof(rKhoHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get()
            };
            _TonCaoNhatFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_TonCaoNhat, nameof(rCanhBaoTonKhoDataModel.TonCaoNhat), typeof(int));
            _TonThapNhatFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_TonThapNhat, nameof(rCanhBaoTonKhoDataModel.TonThapNhat), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_TenantID, nameof(rCanhBaoTonKhoDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_CreateTime, nameof(rCanhBaoTonKhoDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_LastUpdateTime, nameof(rCanhBaoTonKhoDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_TonCaoNhatFilter);
            AddHeaderFilter(_TonThapNhatFilter);
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
            ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(rCanhBaoTonKhoDataModel dataModel)
        {
            dataModel.MaMatHangDataSource = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.Get();
            dataModel.MaKhoHangDataSource = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(rCanhBaoTonKhoDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dataModel.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dataModel.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_TonCaoNhatFilter.FilterValue != null)
            {
                dataModel.TonCaoNhat = (int)_TonCaoNhatFilter.FilterValue;
            }
            if (_TonThapNhatFilter.FilterValue != null)
            {
                dataModel.TonThapNhat = (int)_TonThapNhatFilter.FilterValue;
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
