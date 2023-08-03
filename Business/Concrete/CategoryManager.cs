using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            this.categoryDal = categoryDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(CategoryDto categoryDto)
        {
            var result = BusinessRules.Run(CheckIfCategoryNameExist(categoryDto.Name));
            if (result != null)
            {
                return result;
            }
            var category = _mapper.Map<Category>(categoryDto);

            categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(int id)
        {
            var category = categoryDal.Get(x => x.Id == id);
            if (category == null)
            {
                return new ErrorResult(Messages.IdNotEntered);
            }
            categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetAll(), Messages.CategoryListed);
        }

        public IDataResult<List<CategoryForHomeDto>> GetAllForHome()
        {
            return new SuccessDataResult<List<CategoryForHomeDto>>(categoryDal.CategorForHomeGetAll());
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(categoryDal.Get(x => x.Id == id));
        }

        public IDataResult<CategoryForHomeDto> GetByIdForHome(int id)
        {
            return new SuccessDataResult<CategoryForHomeDto>(categoryDal.GetByIdForHome(id));
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(int id, CategoryDto? categoryDto)
        {
            var dbcat = categoryDal.Get(x => x.Id == id);
            if (dbcat == null) return new ErrorResult(Messages.IdNotEntered);

            if (categoryDto == null) return new ErrorResult(Messages.IdNotEntered);

            var result = BusinessRules.Run(CheckIfCategoryNameExistForUpdate(dbcat.Id, categoryDto.Name));
            if (result != null)
            {
                return result;
            }

            dbcat.Name = categoryDto.Name;
            var category = _mapper.Map<Category>(categoryDto);
            category.Id = id;
            categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }


        #region Business Code
        private IResult CheckIfCategoryNameExist(string categoryName)
        {
            var result = categoryDal.GetAll(x => x.Name == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryNameExistForUpdate(int id, string categoryName)
        {
            var result = categoryDal.GetAll(x => x.Name == categoryName && x.Id != id).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
