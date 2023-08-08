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
    public class SupportAnswerManager : ISupportAnswerService
    {
        private readonly ISupportAnswerDal supportAnswerDal;
        public SupportAnswerManager(ISupportAnswerDal supportAnswerDal)
        {
            this.supportAnswerDal = supportAnswerDal;
        }

        [ValidationAspect(typeof(SupportAnswerValidator))]
        public IResult Add(SupportAnswerDto supportAnswerDto)
        {
            SupportAnswer supportAnswer = new SupportAnswer()
            {
                Content = supportAnswerDto.Content,
                SupportQuestionId = supportAnswerDto.QuestionId
            };

            supportAnswerDal.Add(supportAnswer);

            return new SuccessResult(Messages.SupportAnswerAdded);
        }

        public IDataResult<List<GetSupportAnswerDto>> GetAll() =>
                new SuccessDataResult<List<GetSupportAnswerDto>>(supportAnswerDal.GetSupportAnswersWithQuestions());
    }
}
