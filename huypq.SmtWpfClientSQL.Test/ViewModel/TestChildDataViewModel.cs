using huypq.SmtShared.Test;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Test.View;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace huypq.SmtWpfClientSQL.Test.ViewModel
{
    public partial class TestChildDataViewModel : BaseViewModel<TestChildDataDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TestChildDataDto dto);
        partial void ProcessNewAddedDtoPartial(TestChildDataDto dto);

        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _DataFilter;
        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _TestDataIDFilter;

        public TestChildDataViewModel() : base()
        {
            _CreateTimeFilter = new HeaderTextFilterModel(nameof(TestChildDataDto.CreateTime), nameof(TestChildDataDto.CreateTime), typeof(long));

            _DataFilter = new HeaderTextFilterModel(nameof(TestChildDataDto.Data), nameof(TestChildDataDto.Data), typeof(string));

            _IDFilter = new HeaderTextFilterModel(nameof(TestChildDataDto.ID), nameof(TestChildDataDto.ID), typeof(int));

            _LastUpdateTimeFilter = new HeaderTextFilterModel(nameof(TestChildDataDto.LastUpdateTime), nameof(TestChildDataDto.LastUpdateTime), typeof(long));

            _TenantIDFilter = new HeaderTextFilterModel(nameof(TestChildDataDto.TenantID), nameof(TestChildDataDto.TenantID), typeof(int));

            _TestDataIDFilter = new HeaderComboBoxFilterModel(
                nameof(TestChildDataDto.TestDataID), HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TestChildDataDto.TestDataID),
                typeof(int),
                nameof(TestDataDto.DisplayText),
                nameof(TestDataDto.ID))
            {
                AddCommand = new SimpleCommand("TestDataIDAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new TestDataView(), "TestData", ReferenceDataManager<TestDataDto>.Instance.Update)),
                ItemSource = ReferenceDataManager<TestDataDto>.Instance.Get()
            };

            InitFilterPartial();

            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_DataFilter);
            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_TestDataIDFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TestDataDto>.Instance.Update();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TestChildDataDto dto)
        {
            dto.TestDataIDSources = ReferenceDataManager<TestDataDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TestChildDataDto dto)
        {
            if (_CreateTimeFilter.FilterValue != null)
            {
                dto.CreateTime = (long)_CreateTimeFilter.FilterValue;
            }
            if (_DataFilter.FilterValue != null)
            {
                dto.Data = (string)_DataFilter.FilterValue;
            }
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_LastUpdateTimeFilter.FilterValue != null)
            {
                dto.LastUpdateTime = (long)_LastUpdateTimeFilter.FilterValue;
            }
            if (_TenantIDFilter.FilterValue != null)
            {
                dto.TenantID = (int)_TenantIDFilter.FilterValue;
            }
            if (_TestDataIDFilter.FilterValue != null)
            {
                dto.TestDataID = (int)_TestDataIDFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
