using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;

namespace Shared
{
    public partial class SmtUserDataModel<T> : BaseDataModel<T>, IUserDataModel<T> where T : IDto
    {
        System.DateTime oCreateDate;
        string oEmail;
        string oPasswordHash;
        string oUserName;
        long oTokenValidTime;
        bool oIsConfirmed;
        bool oIsLocked;
        
        System.DateTime _CreateDate;
        string _Email;
        string _PasswordHash;
        string _UserName;
        long _TokenValidTime;
        bool _IsConfirmed;
        bool _IsLocked;
        
        public System.DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; OnPropertyChanged(); } }
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged(); } }
        public string PasswordHash { get { return _PasswordHash; } set { _PasswordHash = value; OnPropertyChanged(); } }
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }
        public long TokenValidTime { get { return _TokenValidTime; } set { _TokenValidTime = value; OnPropertyChanged(); } }
        public bool IsConfirmed { get { return _IsConfirmed; } set { _IsConfirmed = value; OnPropertyChanged(); } }
        public bool IsLocked { get { return _IsLocked; } set { _IsLocked = value; OnPropertyChanged(); } }
        
        public override void SetCurrentValueAsOriginalValue()
        {
            oCreateDate = CreateDate;
            oEmail = Email;
            oPasswordHash = PasswordHash;
            oUserName = UserName;
            oTokenValidTime = TokenValidTime;
            oIsConfirmed = IsConfirmed;
            oIsLocked = IsLocked;
        }

        public override void Update(object obj)
        {
            var dto = obj as SmtUserDataModel<T>;
            if (dto == null)
            {
                return;
            }

            ID = dto.ID;
            CreateDate = dto.CreateDate;
            Email = dto.Email;
            PasswordHash = dto.PasswordHash;
            UserName = dto.UserName;
            TenantID = dto.TenantID;
            TokenValidTime = dto.TokenValidTime;
            LastUpdateTime = dto.LastUpdateTime;
            IsConfirmed = dto.IsConfirmed;
            IsLocked = dto.IsLocked;
            CreateTime = dto.CreateTime;
        }

        public override bool HasChange()
        {
            return
            (oCreateDate != CreateDate) ||
            (oEmail != Email) ||
            (oPasswordHash != PasswordHash) ||
            (oUserName != UserName) ||
            (oTokenValidTime != TokenValidTime) ||
            (oIsConfirmed != IsConfirmed) ||
            (oIsLocked != IsLocked);
        }

        object _TenantIDDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object TenantIDDataSource { get { return _TenantIDDataSource; } set { _TenantIDDataSource = value; OnPropertyChanged(); } }
    }
}
