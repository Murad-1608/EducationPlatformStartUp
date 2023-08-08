using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class SupportQuestionManager : ISupportQuestionService
    {
        private readonly ISupportQuestionDal supportQuestionDal;
        public SupportQuestionManager(ISupportQuestionDal supportQuestionDal)
        {
            this.supportQuestionDal = supportQuestionDal;
        }


        [ValidationAspect(typeof(SupportQuestionValidator))]
        public IResult Add(SupportQuestionDto supportQuestionDto)
        {
            SupportQuestion supportQuestion = new()
            {
                Content = supportQuestionDto.Content
            };
            supportQuestionDal.Add(supportQuestion);

            return new SuccessResult(Messages.SupportQuestionAdded);
        }

        public IDataResult<List<SupportQuestion>> GetAll()
        {
            var questions = supportQuestionDal.GetAll();

            return new SuccessDataResult<List<SupportQuestion>>(questions);
        }

    }
}
