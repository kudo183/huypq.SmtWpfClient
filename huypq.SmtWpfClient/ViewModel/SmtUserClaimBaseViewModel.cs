using huypq.SmtWpfClient.Abstraction;
using huypq.SmtShared;
using SimpleDataGrid.ViewModel;

namespace huypq.SmtWpfClient.ViewModel
{
    public partial class SmtUserClaimBaseViewModel<T, T1> : BaseViewModel<T, T1> where T : class, IUserClaimDto, new() where T1 : class, IUserClaimDataModel<T>, new()
    {
        HeaderFilterBaseModel _UserIDFilter;
        public SmtUserClaimBaseViewModel() : base()
        {
            _UserIDFilter = new HeaderTextFilterModel(nameof(IUserClaimDto.UserID), nameof(IUserClaimDto.UserID), typeof(int));
            _UserIDFilter.IsShowInUI = false;
            AddHeaderFilter(_UserIDFilter);
        }
        protected override void ProcessNewAddedDataModel(T1 dto)
        {
            if (_UserIDFilter.FilterValue != null)
            {
                dto.UserID = (int)_UserIDFilter.FilterValue;
            }
        }
    }
}
