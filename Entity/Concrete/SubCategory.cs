using Core.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete
{
    public class SubCategory : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public List<Course> Courses { get; set; }
    }
}
