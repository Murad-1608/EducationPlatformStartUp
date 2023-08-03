using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class SubCategoryDto : IDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
