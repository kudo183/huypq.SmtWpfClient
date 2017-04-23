using huypq.SmtWpfClient.Abstraction;
using huypq.SmtShared;
using SimpleDataGrid.ViewModel;

namespace huypq.SmtWpfClient.ViewModel
{
    public partial class SmtUserClaimBaseViewModel<T> : BaseViewModel<T> where T : class, SmtIUserClaimDto, new()
    {
        HeaderFilterBaseModel _UserIDFilter;
        public SmtUserClaimBaseViewModel() : base()
        {
            _UserIDFilter = new HeaderTextFilterModel(nameof(SmtIUserClaimDto.UserID), nameof(SmtIUserClaimDto.UserID), typeof(int));
            _UserIDFilter.IsShowInUI = false;
            AddHeaderFilter(_UserIDFilter);
        }
        protected override void ProcessNewAddedDto(T dto)
        {
            if (_UserIDFilter.FilterValue != null)
            {
                dto.UserID = (int)_UserIDFilter.FilterValue;
            }
        }
    }
}
