using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            var result = BusinessRules.Run(CheckIfCategoryNameExist(category.Name));
            if(result != null)
            {
                return result;
            }
            categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(int id)
        {
            var category = categoryDal.Get(x => x.Id == id);
            if(category == null)
            {
                return new ErrorResult(Messages.IdNotEntered);
            }
            categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetAll(),Messages.CategoryListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(categoryDal.Get(x => x.Id == id));
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(int id)
        {
            Category category = categoryDal.Get(x => x.Id == id);
            var result = BusinessRules.Run(CheckIfCategoryNameExistForUpdate(category.Id,category.Name));
            if(result != null)
            {
                return result;
            }
            categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }


        #region Business Code
        private IResult CheckIfCategoryNameExist(string categoryName)
        {
            var result = categoryDal.GetAll(x=>x.Name==categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryNameExistForUpdate(int id,string categoryName)
        {
            var result = categoryDal.GetAll(x => x.Name == categoryName && x.Id!=id).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
