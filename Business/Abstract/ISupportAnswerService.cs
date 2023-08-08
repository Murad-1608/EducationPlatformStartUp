using Core.Utilities.Results;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface ISupportAnswerService
    {
        IResult Add(SupportAnswerDto supportAnswerDto);
        IDataResult<List<GetSupportAnswerDto>> GetAll();
    }
}
