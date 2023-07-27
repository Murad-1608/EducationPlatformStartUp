using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class CourseVideo : IEntity
    {
        public int Id { get; set; }
        public int LessonTitleId { get; set; }
        public LessonTitle LessonTitle { get; set; }
    }
}
