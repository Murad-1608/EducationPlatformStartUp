using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class TeacherForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string InformationVideo { get; set; }
        public string Instagram { get; set; }
        public string TiktTok { get; set; }
        public string YouTube { get; set; }
    }
}
