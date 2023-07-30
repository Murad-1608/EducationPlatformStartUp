using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IFaqService
    {
        IDataResult<List<Faq>> GetAll();
    }
}
