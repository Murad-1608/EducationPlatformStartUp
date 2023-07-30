using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            this.courseDal = courseDal;
        }

        public IDataResult<List<CourseForListDto>> GetCoursesBestSelling()
        {
            var coursesForBestSelling = courseDal.GetCoursesBestSelling();
            return new SuccessDataResult<List<CourseForListDto>>(coursesForBestSelling);
        }

        public IDataResult<List<CourseForListDto>> GetCoursesForStarters()
        {
            var coursesForStarters = courseDal.GetCoursesForStarters();
            return new SuccessDataResult<List<CourseForListDto>>(coursesForStarters);
        }
    }
}
