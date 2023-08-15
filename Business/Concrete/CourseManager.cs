using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Core.Aspects.Autofac.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ValidationRules.FluentValidation;
using Business.Constants;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            this.courseDal = courseDal;
        }

        [ValidationAspect(typeof(CourseValidator))]
        public IResult Add(Course course)
        {
            if (course != null)
            {
                courseDal.Add(course);
                return new SuccessResult(Messages.CourseAdded);
            }
            return new ErrorResult(Messages.CourseNull);
        }

        public IResult Delete(int id)
        {
            var course = courseDal.Get(c => c.Id == id);
            if (course != null)
            {
                courseDal.Delete(course);
                return new SuccessResult(Messages.CourseDeleted);
            }
            return new ErrorResult(Messages.IdNotEntered);
        }

        public IDataResult<List<Course>> GetAll()
        {
            var courses = courseDal.GetAll();
            return new SuccessDataResult<List<Course>>(courses);
        }

        public IDataResult<Course> GetById(int id)
        {
            var course = courseDal.Get(c => c.Id == id);
            return new SuccessDataResult<Course>(course);
        }

        public IDataResult<List<CourseForCoursePageDto>> GetByName(string name)
        {
            return new SuccessDataResult<List<CourseForCoursePageDto>>(courseDal.GetWithTeacher(x => x.Name.Contains(name)));
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

        public IDataResult<List<CourseForCoursePageDto>> GetForCoursePage()
        {
            return new SuccessDataResult<List<CourseForCoursePageDto>>(courseDal.GetWithTeacher());
        }

        [ValidationAspect(typeof(CourseValidator))]
        public IResult Update(Course course)
        {
            if (course != null)
            {
                courseDal.Update(course);
                return new SuccessResult(Messages.CourseUpdated);
            }
            return new ErrorResult(Messages.CourseNull);
        }
    }
}
