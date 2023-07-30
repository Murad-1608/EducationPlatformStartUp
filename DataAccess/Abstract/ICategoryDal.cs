using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IRepositoryBase<Category>
    {
        List<CategoryForHomeDto> CategorForHomeGetAll();
        CategoryForHomeDto GetByIdForHome(int id);
    }
}
