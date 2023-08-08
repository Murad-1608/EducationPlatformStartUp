using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface ISupportQuestionService
    {
        IDataResult<List<SupportQuestion>> GetAll();
        IResult Add(SupportQuestionDto supportQuestionDto);
    }
}
