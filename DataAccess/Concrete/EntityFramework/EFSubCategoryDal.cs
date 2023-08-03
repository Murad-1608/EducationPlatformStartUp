using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFSubCategoryDal : EfRepositoryBase<SubCategory, AppDbContext>, ISubCategoryDal
    {
        public List<SubCategoryWithBaseCategoryDto> GetAllWithBaseCategory()
        {
            using var context = new AppDbContext();

            var subCategory = context.SubCategories.Include(x => x.Category).ToList();
            List<SubCategoryWithBaseCategoryDto> subCategoryWithBaseCategories = new List<SubCategoryWithBaseCategoryDto>();

            foreach (var item in subCategory)
            {
                SubCategoryWithBaseCategoryDto scwd = new SubCategoryWithBaseCategoryDto
                {
                    Id=item.Id,
                    Subcategory = item.Name,
                    Category = item.Category.Name
                };
                subCategoryWithBaseCategories.Add(scwd);
            }
            return subCategoryWithBaseCategories;
        }

        public SubCategoryWithBaseCategoryDto GetByIdWithBaseCategory(int id)
        {
            using var context = new AppDbContext();
            SubCategory subCategory = context.SubCategories.Include(x => x.Category).FirstOrDefault(x=>x.Id==id);
            SubCategoryWithBaseCategoryDto subCategoryWithBaseCategoryDto = new SubCategoryWithBaseCategoryDto
            {
                Id=subCategory.Id,
                Subcategory = subCategory.Name,
                Category = subCategory.Category.Name
            };
            return subCategoryWithBaseCategoryDto;
        }
    }
}
