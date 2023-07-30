using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class CourseForListDto:IDto
    {
        public string CourseName { get; set; }
        public string TeacherFullName { get; set; }
        public int Review { get; set; }
        public int NumberOfStudent { get; set; }
        public int VideoCount { get; set; }
        //public decimal PriceOfBonus { get; set; }
        public decimal Price { get; set; }
    }
}
