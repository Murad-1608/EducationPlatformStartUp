using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        [ValidationAspect(typeof(SubCategoryValidator))]
        public IResult Add(SubCategory subCategory,int categoryId)
        {
            var result = BusinessRules.Run(CheckIfSubCategoryNameExist(subCategory.Name));
            if (result !=null)
            {
                return result;
            }
            subCategory.CategoryId = categoryId;
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

        public IDataResult<SubCategory> GetById(int id)
        {
            return new SuccessDataResult<SubCategory>(_subCategoryDal.Get(x => x.Id == id));
        }

        [ValidationAspect(typeof(SubCategoryValidator))]
        public IResult Update(int id,int categoryId)
        {
            SubCategory subCategory = _subCategoryDal.Get(x => x.Id == id);
            var result = BusinessRules.Run(CheckIfSubCategoryNameExistForUpdate(subCategory.Name, subCategory.Id));
            if(result != null)
            {
                return result;
            }
            subCategory.CategoryId = categoryId;
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
