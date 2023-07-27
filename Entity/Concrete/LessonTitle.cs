using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class LessonTitle : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public List<CourseVideo> CourseVideos { get; set; }
    }
}
