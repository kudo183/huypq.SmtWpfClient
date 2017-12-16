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
    public partial class tMatHangViewModel : BaseViewModel<tMatHangDto, tMatHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tMatHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tMatHangDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaLoaiFilter;
        HeaderFilterBaseModel _TenMatHangFilter;
        HeaderFilterBaseModel _SoKyFilter;
        HeaderFilterBaseModel _SoMetFilter;
        HeaderFilterBaseModel _TenMatHangDayDuFilter;
        HeaderFilterBaseModel _TenMatHangInFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;
        HeaderFilterBaseModel _MaHinhAnhFilter;

        public tMatHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tMatHang_ID, nameof(tMatHangDataModel.ID), typeof(int));
            _MaLoaiFilter = new HeaderComboBoxFilterModel(
                TextManager.tMatHang_MaLoai, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tMatHangDataModel.MaLoai),
                typeof(int),
                nameof(rLoaiHangDataModel.DisplayText),
                nameof(rLoaiHangDataModel.ID))
            {
                AddCommand = new SimpleCommand("MaLoaiAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rLoaiHangView(), "rLoaiHang", ReferenceDataManager<rLoaiHangDto, rLoaiHangDataModel>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rLoaiHangDto, rLoaiHangDataModel>.Instance.Get()
            };
            _TenMatHangFilter = new HeaderTextFilterModel(TextManager.tMatHang_TenMatHang, nameof(tMatHangDataModel.TenMatHang), typeof(string));
            _SoKyFilter = new HeaderTextFilterModel(TextManager.tMatHang_SoKy, nameof(tMatHangDataModel.SoKy), typeof(int));
            _SoMetFilter = new HeaderTextFilterModel(TextManager.tMatHang_SoMet, nameof(tMatHangDataModel.SoMet), typeof(int));
            _TenMatHangDayDuFilter = new HeaderTextFilterModel(TextManager.tMatHang_TenMatHangDayDu, nameof(tMatHangDataModel.TenMatHangDayDu), typeof(string));
            _TenMatHangInFilter = new HeaderTextFilterModel(TextManager.tMatHang_TenMatHangIn, nameof(tMatHangDataModel.TenMatHangIn), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tMatHang_TenantID, nameof(tMatHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tMatHang_CreateTime, nameof(tMatHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tMatHang_LastUpdateTime, nameof(tMatHangDataModel.LastUpdateTime), typeof(long));
            _MaHinhAnhFilter = new HeaderTextFilterModel(TextManager.tMatHang_MaHinhAnh, nameof(tMatHangDataModel.MaHinhAnh), typeof(int));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaLoaiFilter);
            AddHeaderFilter(_TenMatHangFilter);
            AddHeaderFilter(_SoKyFilter);
            AddHeaderFilter(_SoMetFilter);
            AddHeaderFilter(_TenMatHangDayDuFilter);
            AddHeaderFilter(_TenMatHangInFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
            AddHeaderFilter(_MaHinhAnhFilter);
        }

        protected override void AfterLoad()
        {

            AfterLoadPartial();
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rLoaiHangDto, rLoaiHangDataModel>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tMatHangDataModel dataModel)
        {
            dataModel.MaLoaiDataSource = ReferenceDataManager<rLoaiHangDto, rLoaiHangDataModel>.Instance.Get();

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tMatHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaLoaiFilter.FilterValue != null)
            {
                dataModel.MaLoai = (int)_MaLoaiFilter.FilterValue;
            }
            if (_TenMatHangFilter.FilterValue != null)
            {
                dataModel.TenMatHang = (string)_TenMatHangFilter.FilterValue;
            }
            if (_SoKyFilter.FilterValue != null)
            {
                dataModel.SoKy = (int)_SoKyFilter.FilterValue;
            }
            if (_SoMetFilter.FilterValue != null)
            {
                dataModel.SoMet = (int)_SoMetFilter.FilterValue;
            }
            if (_TenMatHangDayDuFilter.FilterValue != null)
            {
                dataModel.TenMatHangDayDu = (string)_TenMatHangDayDuFilter.FilterValue;
            }
            if (_TenMatHangInFilter.FilterValue != null)
            {
                dataModel.TenMatHangIn = (string)_TenMatHangInFilter.FilterValue;
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
            if (_MaHinhAnhFilter.FilterValue != null)
            {
                dataModel.MaHinhAnh = (int)_MaHinhAnhFilter.FilterValue;
            }

            ProcessNewAddedDataModelPartial(dataModel);
            ProcessDataModelBeforeAddToEntities(dataModel);
        }
    }
}
