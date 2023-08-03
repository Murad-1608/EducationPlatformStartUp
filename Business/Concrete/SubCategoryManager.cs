using AutoMapper;
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
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly ISubCategoryDal _subCategoryDal;
        private readonly IMapper _mapper;
        public SubCategoryManager(ISubCategoryDal subCategoryDal,IMapper mapper)
        {
            _subCategoryDal = subCategoryDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(SubCategoryValidator))]
        public IResult Add(SubCategoryDto subCategoryDto)
        {
            var result = BusinessRules.Run(CheckIfSubCategoryNameExist(subCategoryDto.Name));
            if (result !=null)
            {
                return result;
            }
            var subCategory = _mapper.Map<SubCategory>(subCategoryDto);
            _subCategoryDal.Add(subCategory);
            return new SuccessResult(Messages.SubCategoryAdded);
        }

        public IResult Delete(int id)
        {
            var subCategory = _subCategoryDal.Get(x => x.Id == id);
            if (subCategory ==null)
            {
                return new ErrorResult(Messages.IdNotEnteredSub);
            }
            _subCategoryDal.Delete(subCategory);
            return new SuccessResult(Messages.SubCategoryDeleted);
        }

        public IDataResult<List<SubCategory>> GetAll()
        {
           return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetAll(),Messages.SubCategoryListed);
        }

        public IDataResult<List<SubCategoryWithBaseCategoryDto>> GetAllWithBaseCategory()
        {
            return new SuccessDataResult<List<SubCategoryWithBaseCategoryDto>>(_subCategoryDal.GetAllWithBaseCategory());
        }

        public IDataResult<SubCategory> GetById(int id)
        {
            return new SuccessDataResult<SubCategory>(_subCategoryDal.Get(x => x.Id == id));
        }


        public IDataResult<SubCategoryWithBaseCategoryDto> GetByIdWithBaseCategory(int id)
        {
            var result = _subCategoryDal.GetByIdWithBaseCategory(id);      
            return new SuccessDataResult<SubCategoryWithBaseCategoryDto>(result);
        }


        [ValidationAspect(typeof(SubCategoryValidator))]
        public IResult Update(SubCategory subCategory)
        {    
            var result = BusinessRules.Run(CheckIfSubCategoryNameExistForUpdate(subCategory.Name, subCategory.Id));
            if(result != null)
            {
                return result;
            }
            _subCategoryDal.Update(subCategory);
            return new SuccessResult(Messages.SubCategoryUpdated);
        }

        #region Business Code
        private IResult CheckIfSubCategoryNameExist(string subCategoryName)
        {
            var result = _subCategoryDal.GetAll(x=>x.Name== subCategoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.SubCategoryNameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfSubCategoryNameExistForUpdate(string subCategoryName,int id)
        {
            var result = _subCategoryDal.GetAll(x => x.Name == subCategoryName && x.Id!=id).Any();
            if (result)
            {
                return new ErrorResult(Messages.SubCategoryNameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
