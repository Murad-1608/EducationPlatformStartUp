using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.DTOs
{
    public class CategoryForHomeDto : IDto
    {
        public string BaseCategory { get; set; }
        public List<string> SubCategories { get; set; }
    }
}
