using Core.Entity.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class CategoryForHomeDto : IDto
    {
        public string BaseCategory { get; set; }
        public List<SubCategory> ChildCategory { get; set; }
    }
}
