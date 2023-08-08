using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class FaqAnswerUpdateDto
    {        
        public int FaqId { get; set; }
        public string Answer { get; set; }
    }
}
