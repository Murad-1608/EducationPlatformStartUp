using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class FaqUpdateDto : IDto
    {
        public string Question { get; set; }
        public bool Status { get; set; }
    }
}
