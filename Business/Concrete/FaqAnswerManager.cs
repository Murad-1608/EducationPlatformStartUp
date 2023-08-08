using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FaqAnswerManager : IFaqAnswerService
    {

        private readonly IFaqAnswerDal _faqAnswerDal;
        private readonly IMapper _mapper;
        public FaqAnswerManager(IFaqAnswerDal faqAnswerDal, IMapper mapper)
        {
            _faqAnswerDal = faqAnswerDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(FaqAnswerValidator))]
        public IResult Add(FaqAnswerCreateDto? faqAnswerCreateDto)
        {
            if (faqAnswerCreateDto is null) return new ErrorResult(Messages.ItemNull_FAQAnswer);

            var faqAnswer = _mapper.Map<FaqAnswer>(faqAnswerCreateDto);

            _faqAnswerDal.Add(faqAnswer);
            return new SuccessResult(Messages.ItemAdded_FAQAnswer);
        }

        public IResult Delete(int? id)
        {
            if (id == null) return new ErrorDataResult<Faq>(Messages.NullId_FAQAnswer);

            var item = _faqAnswerDal.Get(f => f.Id == id);
            if (item is null) return new ErrorResult(Messages.ItemNotFound_FAQAnswer);

            _faqAnswerDal.Delete(item);
            return new SuccessResult(Messages.ItemDeleted_FAQAnswer);
        }        

        public IDataResult<List<FaqAnswer>> GetAll()
        => new SuccessDataResult<List<FaqAnswer>>(_faqAnswerDal.GetAll());

        public IDataResult<FaqAnswer> GetById(int? id)
        {
            if (id == null) return new ErrorDataResult<FaqAnswer>(Messages.NullId_FAQAnswer);

            var _faqAnswer = _faqAnswerDal.Get(x => x.Id == id);
            if (_faqAnswer is null) return new ErrorDataResult<FaqAnswer>(Messages.ItemNotFound_FAQAnswer);

            return new SuccessDataResult<FaqAnswer>(_faqAnswer);
        }

        [ValidationAspect(typeof(FaqValidator))]
        public IResult UpdateFaqAnswer(int? id, FaqAnswerUpdateDto? faqAnswerUpdateDto)
        {
            if (id is null) return new ErrorResult(Messages.NullId_FAQAnswer);
            var faqAnswerInDb = _faqAnswerDal.Get(f => f.Id == id);
            if (faqAnswerInDb is null) return new ErrorResult(Messages.ItemNotFound_FAQAnswer);
            var faqAnswer = _mapper.Map<FaqAnswer>(faqAnswerUpdateDto);
            _faqAnswerDal.Update(faqAnswer);
            return new SuccessResult(Messages.StatusUpdated_FAQ);
        }
    }
}
