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
    public interface ICourseService
    {
        IDataResult<List<Course>> GetAll();
        IDataResult<List<CourseForListDto>> GetCoursesForStarters();
        IDataResult<List<CourseForListDto>> GetCoursesBestSelling();
        IDataResult<Course> GetById(int id);
        IResult Add(Course course);
        IResult Update(Course course);
        IResult Delete(int id);
        IDataResult<List<CourseForCoursePageDto>> GetByName(string name);
        IDataResult<List<CourseForCoursePageDto>> GetForCoursePage();
    }
}
