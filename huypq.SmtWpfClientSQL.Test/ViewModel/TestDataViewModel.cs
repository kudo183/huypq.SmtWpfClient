using huypq.SmtSharedTest;
using huypq.SmtWpfClient.Abstraction;
using SimpleDataGrid.ViewModel;

namespace huypq.SmtWpfClientSQL.Test.ViewModel
{
    public partial class TestDataViewModel : BaseViewModel<TestDataDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TestDataDto dto);
        partial void ProcessNewAddedDtoPartial(TestDataDto dto);

        HeaderFilterBaseModel _DataFilter;
        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public TestDataViewModel() : base()
        {
            _DataFilter = new HeaderTextFilterModel(nameof(TestDataDto.Data), nameof(TestDataDto.Data), typeof(string));

            _IDFilter = new HeaderTextFilterModel(nameof(TestDataDto.ID), nameof(TestDataDto.ID), typeof(int));

            _LastUpdateTimeFilter = new HeaderTextFilterModel(nameof(TestDataDto.LastUpdateTime), nameof(TestDataDto.LastUpdateTime), typeof(long));

            InitFilterPartial();

            AddHeaderFilter(_DataFilter);
            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(TestDataDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TestDataDto dto)
        {
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

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
