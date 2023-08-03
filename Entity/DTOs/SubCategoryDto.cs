using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class SubCategoryDto : IDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
