using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepositoryBase<Category, AppDbContext>, ICategoryDal
    {
        public List<CategoryForHomeDto> CategorForHomeGetAll()
        {
            using var context = new AppDbContext();

            List<Category> categories = context.Categories.Include(x=>x.SubCategories).ToList();
            List<CategoryForHomeDto> categoryHomeDto = new List<CategoryForHomeDto>();

            foreach (var item in categories)
            {
                CategoryForHomeDto cathomedto = new CategoryForHomeDto
                {
                    Id=item.Id,
                    BaseCategory = item.Name,
                    SubCategories = item.SubCategories
                                .Where(subCategory => subCategory.CategoryId == item.Id)
                                .Select(subCategory => subCategory.Name)
                                .ToList()
                };
                categoryHomeDto.Add(cathomedto);
            }
            return categoryHomeDto;
        }

        public CategoryForHomeDto GetByIdForHome(int id)
        {
            using var context = new AppDbContext();

            Category category = context.Categories.Include(x => x.SubCategories).FirstOrDefault(x => x.Id == id);
            CategoryForHomeDto categoryForHomeDto = new CategoryForHomeDto
            {
                Id=category.Id,
                BaseCategory = category.Name,
                SubCategories = category.SubCategories
                                .Where(subCategory => subCategory.CategoryId == category.Id)
                                .Select(subCategory => subCategory.Name)
                                .ToList()
            };
            return categoryForHomeDto;
        }
    }
}
