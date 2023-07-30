using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class TeacherForHomeDto : IDto
    {
        public string Name { get; set; }
        public string InformationVideo { get; set; }
        public string Tiktok { get; set; }
        public string Instagram { get; set; }
        public string YouTube { get; set; }
    }
}
