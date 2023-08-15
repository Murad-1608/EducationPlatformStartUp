using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class CourseForCoursePageDto : IDto
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int Review { get; set; }
        public int VideoCount { get; set; }
        public int NamberOfStudent { get; set; }
        public decimal BonusPrice { get; set; }
        public decimal Price { get; set; }
        public string MiniDetails { get; set; }
    }
}
