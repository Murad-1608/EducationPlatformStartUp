using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IFaqService
    {
        IDataResult<List<Faq>> GetAll();
        IDataResult<Faq> GetById(int? id);
        IResult Add(Faq? faq);
        IResult Delete(int? id);
        IResult UpdateFaq(int? id, FaqUpdateDto? faqUpdateDto);
        IResult UpdateFaqStatus(int? id, bool? status);
    }
}
