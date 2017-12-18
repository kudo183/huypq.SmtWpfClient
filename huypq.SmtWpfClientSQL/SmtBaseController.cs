using huypq.SmtShared;
using huypq.SmtShared.Constant;
using huypq.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using huypq.wpf.Utils;
using System.Collections.Specialized;


namespace huypq.SmtWpfClientSQL
{
    public abstract class SmtBaseController<ContextType, TenantEntityType, UserEntityType, UserClaimEntityType> : IDataProvider
        where TenantEntityType : class, ITenant, new()
        where UserEntityType : class, IUser, new()
        where UserClaimEntityType : class, IUserClaim
        where ContextType : DbContext, IDbContext<TenantEntityType, UserEntityType, UserClaimEntityType>
    {
        ContextType _context = ServiceLocator.Get<IDbContext>() as ContextType;

        public object ActionInvoker(string actionName, object parameters)
        {
            object result = null;

            switch (actionName)
            {
                case ControllerAction.Smt.Register:
                    result = Register(parameters as NameValueCollection);
                    break;
                case ControllerAction.Smt.TenantLogin:
                    result = TenantLogin(parameters as NameValueCollection);
                    break;
                default:
                    break;
            }

            return result;
        }

        protected object Register(NameValueCollection parameters)
        {
            var user = parameters["user"];
            var tenantName = parameters["tenantname"];

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(tenantName))
            {
                throw new Exception("user/tenantName cannot empty");
            }

            var validate = 0;

            if (_context.SmtTenant.Any(p => p.Email == user))
            {
                validate = validate + 1;
            }

            if (_context.SmtTenant.Any(p => p.TenantName == tenantName))
            {
                validate = validate + 2;
            }

            switch (validate)
            {
                case 1:
                    throw new Exception("Username not available");
                case 2:
                    throw new Exception("Tenant name not available");
                case 3:
                    throw new Exception("Username and Tenant name not available");
            }

            var entity = new TenantEntityType()
            {
                Email = user,
                PasswordHash = string.Empty,
                CreateDate = DateTime.UtcNow,
                TenantName = tenantName,
                TokenValidTime = DateTime.UtcNow.Ticks
            };
            _context.SmtTenant.Add(entity);

            _context.SaveChanges();

            //MailUtils.SendTenantToken(user, TokenPurpose.ResetPassword);

            return "OK";
        }

        protected object TenantLogin(NameValueCollection parameters)
        {
            var user = parameters["user"];
            var pass = parameters["pass"];

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                throw new Exception("user/pass cannot empty");
            }

            var tenantEntity = _context.SmtTenant.FirstOrDefault(p => p.Email == user);
            if (tenantEntity == null)
            {
                throw new Exception("NotFound");
            }

            if (tenantEntity.IsLocked == true)
            {
                throw new Exception("User is locked");
            }

            //var result = Crypto.PasswordHash.VerifyHashedPassword(tenantEntity.PasswordHash, pass);
            var result = true;
            if (result == false)
            {
                throw new Exception("wrong password");
            }

            LoginToken.Instance.TenantName = tenantEntity.TenantName;
            LoginToken.Instance.TenantID = tenantEntity.ID;
            LoginToken.Instance.Claims.Add("*", new List<string>());
            return "OK";
        }
    }
}
