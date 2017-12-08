using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;

namespace Shared
{
    public partial class SmtUserClaimDataModel<T> : BaseDataModel<T>, IUserClaimDataModel<T> where T : IDto
    {
        int oUserID;
        string oClaim;

        int _UserID;
        string _Claim;

        public int UserID { get { return _UserID; } set { SetField(ref _UserID, value); } }
        public string Claim { get { return _Claim; } set { SetField(ref _Claim, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oUserID = UserID;
            oClaim = Claim;
        }

        public override void Update(object obj)
        {
            var dto = obj as SmtUserClaimDataModel<T>;
            if (dto == null)
            {
                return;
            }

            ID = dto.ID;
            UserID = dto.UserID;
            Claim = dto.Claim;
            TenantID = dto.TenantID;
            LastUpdateTime = dto.LastUpdateTime;
            CreateTime = dto.CreateTime;
        }

        public override bool HasChange()
        {
            return
            (oUserID != UserID) ||
            (oClaim != Claim);
        }

        object _UserIDDataSource;
        object _TenantIDDataSource;

        public object UserIDDataSource { get { return _UserIDDataSource; } set { SetField(ref _UserIDDataSource, value); } }
        public object TenantIDDataSource { get { return _TenantIDDataSource; } set { SetField(ref _TenantIDDataSource, value); } }
    }
}
