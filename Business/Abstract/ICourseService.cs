using Core.Utilities.Results;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<List<CourseForListDto>> GetCoursesForStarters();
        IDataResult<List<CourseForListDto>> GetCoursesBestSelling();
    }
}
