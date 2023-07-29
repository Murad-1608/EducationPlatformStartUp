using Core.Entity.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Profession { get; set; }
        public string InformationVideo { get; set; }
        public string Instagram { get; set; }
        public string TiktTok { get; set; }
        public string YouTube { get; set; }

        public User User { get; set; }
        public List<Course> Courses { get; set; }
    }
}
