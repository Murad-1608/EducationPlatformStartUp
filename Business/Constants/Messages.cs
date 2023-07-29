using Core.Entity.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Giriş qadağandır";
        public static string UserRegistered = "Qeydiyyat uğurla yekunlaşdı";
        public static string UserNotFound = "İstifadəçi mövcud deyildir";
        public static string PasswordError = "İstifadəçi adı və ya şifrə yanlışdır";
        public static string SuccessfulLogin = "Login uğurla yekunlaşdı";
        public static string UserAlreadyExists = "Bu email-də istifadəçi mövcuddur";
        public static string AccessTokenCreated = "Token yaradıldı";

        public static string SuccessfulLoginForTeacher = "Qeydiyyat uğurla yekunlaşdı. Təstiqlənəndən sonra email hesabınıza təstiq mesajı gələcəkdir.";
    }
}
