using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ISubCategoryService  
    {
        IDataResult<List<SubCategory>> GetAll();
        IDataResult<SubCategory> GetById(int id);
        IResult Add(SubCategory subCategory,int categoryId);     
        IResult Update(int id,int categoryId);
        IResult Delete(int id);       
    }
}
