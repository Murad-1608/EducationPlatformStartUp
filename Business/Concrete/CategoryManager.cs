using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

       
        public IDataResult<List<Category>> GetAll()
        {
            var categories = categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(categories);
        }
    }
}
