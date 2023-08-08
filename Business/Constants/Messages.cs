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

        public static string CategoryListed = "Kateqoriya uğurla Listələndi";
        public static string CategoryNameExisted = "Bu adda kateqoriya hal-hazırda mövcuddur";
        public static string CategoryAdded = "Kateqoriya əlavə olundu";
        public static string CategoryUpdated = "Kateqoriya yeniləndi";
        public static string CategoryDeleted = "Kateqoriya silindi";
        public static string IdNotEntered = "Bu Id-də heç bir kateqoriya mövcud deyil";
        public static string IdNullCategory = "Id daxil edilməyib";

        public static string SubCategoryListed = "Alt Kateqoriya uğurla Listələndi";
        public static string SubCategoryNameExisted = "Bu adda alt kateqoriya hal-hazırda mövcuddur";
        public static string SubCategoryAdded = "Alt Kateqoriya əlavə olundu";
        public static string SubCategoryUpdated = "Alt Kateqoriya yeniləndi";
        public static string IdNotEnteredSub = "Bu Id-də heç bir alt kateqoriya mövcud deyil";
        public static string SubCategoryDeleted = " Alt Kateqoriya silindi";


        public static string ItemNull_FAQ = "FAQ daxil edilməyib";
        public static string ItemNotFound_FAQ = "FAQ mövcud deyil";
        public static string ItemExists_FAQ = "FAQ mövcuddur";
        public static string ItemAdded_FAQ = "FAQ əlavə olundu";
        public static string NullId_FAQ = "Id daxil edilməyib";
        public static string ItemDeleted_FAQ = "FAQ silindi";
        public static string ItemUpdated_FAQ = "FAQ yeniləndi";
        public static string StatusNull_FAQ = "status daxil edilməyib";
        public static string StatusUpdated_FAQ = "FAQ yeniləndi";

        public static string SupportQuestionAdded = "Sual əlavə olundu";
    }
}


