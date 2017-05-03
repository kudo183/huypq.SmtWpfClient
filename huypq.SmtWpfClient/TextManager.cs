namespace huypq.SmtWpfClient
{
    public class TextManager
    {
        static TextManager()
        {
            ok = "OK";
            changePasswordTitle = "Change Password";
            currentPassword = "Current Password";
            newPassword = "New Password";
            confirmNewPassword = "Confirm New Password";
            login = "Login";
            register = "Register";
            resetPassword = "Reset Password";
            tenantName = "Tenant Name";
            email = "Email";
            password = "Password";
            userLogin = "User Login";
            tenantLogin = "Tenant Login";
            token = "Token";
            userReset = "User Reset";
            tenantReset = "Tenant Reset";
        }

        private static string ok;
        public static string OK { get { return ok; } set { ok = value; } }

        private static string changePasswordTitle;
        public static string ChangePasswordTitle { get { return changePasswordTitle; } set { changePasswordTitle = value; } }

        private static string currentPassword;
        public static string CurrentPassword { get { return currentPassword; } set { currentPassword = value; } }

        private static string newPassword;
        public static string NewPassword { get { return newPassword; } set { newPassword = value; } }

        private static string confirmNewPassword;
        public static string ConfirmNewPassword { get { return confirmNewPassword; } set { confirmNewPassword = value; } }

        private static string login;
        public static string Login { get { return login; } set { login = value; } }

        private static string register;
        public static string Register { get { return register; } set { register = value; } }

        private static string resetPassword;
        public static string ResetPassword { get { return resetPassword; } set { resetPassword = value; } }

        private static string tenantName;
        public static string TenantName { get { return tenantName; } set { tenantName = value; } }

        private static string email;
        public static string Email { get { return email; } set { email = value; } }

        private static string password;
        public static string Password { get { return password; } set { password = value; } }

        private static string userLogin;
        public static string UserLogin { get { return userLogin; } set { userLogin = value; } }

        private static string tenantLogin;
        public static string TenantLogin { get { return tenantLogin; } set { tenantLogin = value; } }

        private static string token;
        public static string Token { get { return token; } set { token = value; } }

        private static string userReset;
        public static string UserReset { get { return userReset; } set { userReset = value; } }

        private static string tenantReset;
        public static string TenantReset { get { return tenantReset; } set { tenantReset = value; } }
    }
}
