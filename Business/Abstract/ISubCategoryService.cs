using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface ISubCategoryService  
    {
        IDataResult<List<SubCategory>> GetAll();
        IDataResult<List<SubCategoryWithBaseCategoryDto>> GetAllWithBaseCategory();
        IDataResult<SubCategoryWithBaseCategoryDto> GetByIdWithBaseCategory(int id);
        IDataResult<SubCategory> GetById(int id);
        IResult Add(SubCategory subCategory);     
        IResult Update(SubCategory subCategory);
        IResult Delete(int id);       
    }
}
