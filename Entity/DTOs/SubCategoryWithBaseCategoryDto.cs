using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.DTOs
{
    public class SubCategoryWithBaseCategoryDto : IDto
    {
        public int Id { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }

    }
}
