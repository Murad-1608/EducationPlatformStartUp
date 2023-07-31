using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Abstract
{
    public interface ISubCategoryDal : IRepositoryBase<SubCategory>
    {
        List<SubCategoryWithBaseCategoryDto> GetAllWithBaseCategory();
        SubCategoryWithBaseCategoryDto GetByIdWithBaseCategory(int id);
    }
}
