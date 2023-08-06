using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<List<CategoryForHomeDto>> GetAllForHome();
        IDataResult<Category> GetById(int id);
        IDataResult<CategoryForHomeDto> GetByIdForHome(int id);
        IResult Add(CategoryDto categoryDto);
        IResult Update(int id, CategoryDto? categoryDto);
        IResult Delete(int id);
    }
}
