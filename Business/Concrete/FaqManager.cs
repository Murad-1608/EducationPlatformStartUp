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
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class FaqManager : IFaqService
    {
        private readonly IFaqDal _faqDal;
        public FaqManager(IFaqDal faqDal)
        {
            _faqDal = faqDal;
        }

        public IDataResult<List<Faq>> GetAll()
        => new SuccessDataResult<List<Faq>>(_faqDal.GetAll(f=>f.Status==true));

        // status'un true və ya false olmasından asılı olmayaraq uyğun id'dəki faq'ı qaytarır 
        public IDataResult<Faq> GetById(int? id)
        {
            if (id==null) return new ErrorDataResult<Faq>(Messages.NullId_FAQ);            

            var _faq = _faqDal.Get(x => x.Id == id);
            if (_faq is null) return new ErrorDataResult<Faq>(Messages.ItemNotFound_FAQ);

            return new SuccessDataResult<Faq>(_faq);
        }


        [ValidationAspect(typeof(FaqValidator))]
        public IResult Add(Faq? faq)
        {
            if (faq is null) return new ErrorResult(Messages.ItemNull_FAQ);

            var question = _faqDal.Get(f=>f.Question==faq.Question);
            if (question is not null) return new ErrorResult(Messages.ItemExists_FAQ);
            faq.Status = false;
            _faqDal.Add(faq);

            return new SuccessResult(Messages.ItemAdded_FAQ);
        }

        public IResult Delete(int? id)
        {
            if (id == null) return new ErrorDataResult<Faq>(Messages.NullId_FAQ);

            var item = _faqDal.Get(f=>f.Id==id);
            if (item is null) return new ErrorResult(Messages.ItemNotFound_FAQ);

            _faqDal.Delete(item);
            return new SuccessResult(Messages.ItemDeleted_FAQ);
        }

        [ValidationAspect(typeof(FaqValidator))]
        public IResult UpdateFaq(int? id, FaqUpdateDto? faqUpdateDto)
        {
            if (id == null) return new ErrorResult(Messages.NullId_FAQ);
            if (faqUpdateDto is null) return new ErrorResult(Messages.ItemNull_FAQ);

            var faqInDb = _faqDal.Get(f=>f.Id==id);
            if (faqInDb is null) return new ErrorResult(Messages.ItemNotFound_FAQ);

            faqInDb.Question = faqUpdateDto.Question;
            faqInDb.Status = faqUpdateDto.Status;
            _faqDal.Update(faqInDb);
            
            return new SuccessResult(Messages.ItemUpdated_FAQ);
        }

        [ValidationAspect(typeof(FaqValidator))]
        public IResult UpdateFaqStatus(int? id, bool? status)
        {
            if (id is null) return new ErrorResult(Messages.NullId_FAQ);
            if (status is null) return new ErrorResult(Messages.StatusNull_FAQ);

            var faqInDb = _faqDal.Get(f => f.Id == id);
            if (faqInDb is null) return new ErrorResult(Messages.ItemNotFound_FAQ);
            
            faqInDb.Status = status;
            _faqDal.Update(faqInDb);

            return new SuccessResult(Messages.StatusUpdated_FAQ);
        }
       


    }
}
