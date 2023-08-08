using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Abstract
{
    public interface ISupportAnswerDal : IRepositoryBase<SupportAnswer>
    {
        List<GetSupportAnswerDto> GetSupportAnswersWithQuestions();
    }
}
