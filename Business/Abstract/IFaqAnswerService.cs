using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFaqAnswerService
    {
        IDataResult<List<FaqAnswer>> GetAll();
        IDataResult<FaqAnswer> GetById(int? id);
        IResult Add(FaqAnswerCreateDto? faqAnswerCreateDto);
        IResult Delete(int? id);
        IResult UpdateFaqAnswer(int? id, FaqAnswerUpdateDto? faqAnswerUpdateDto);        
    }
}
