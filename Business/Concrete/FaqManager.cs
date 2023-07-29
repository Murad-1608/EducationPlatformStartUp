using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class FaqManager : IFaqService
    {
        private readonly IFaqDal faqDal;
        public FaqManager(IFaqDal faqDal)
        {
            this.faqDal = faqDal;
        }

        public IDataResult<List<Faq>> GetAll()
        {
            var values = faqDal.GetAll();

            return new SuccessDataResult<List<Faq>>(values);
        }
    }
}
