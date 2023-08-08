using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSupportAnswerDal : EfRepositoryBase<SupportAnswer, AppDbContext>, ISupportAnswerDal
    {
        public List<GetSupportAnswerDto> GetSupportAnswersWithQuestions()
        {
            using AppDbContext appDbContext = new AppDbContext();

            var answers = appDbContext.SupportAnswers.Include(x => x.SupportQuestion).ToList();

            List<GetSupportAnswerDto> supportAnswersList = new List<GetSupportAnswerDto>();

            foreach (var answer in answers)
            {
                GetSupportAnswerDto supportAnswer = new GetSupportAnswerDto()
                {
                    Answer = answer.Content,
                    Question = answer.SupportQuestion.Content
                };
                supportAnswersList.Add(supportAnswer);
            }
            return supportAnswersList;
        }
    }
}
