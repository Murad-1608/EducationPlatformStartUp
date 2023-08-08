using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : EfRepositoryBase<Course, AppDbContext>, ICourseDal
    {
        public List<CourseForListDto> GetCoursesBestSelling()
        {
            using var context = new AppDbContext();
            var courses = context.Courses.ToList();
            List<CourseForListDto> courseForListDtos = new List<CourseForListDto>();
            foreach(var course in courses)
            {
                var lessontitle = context.LessonTitles.FirstOrDefault(lt => lt.CourseId == course.Id);
                var videocount = lessontitle.CourseVideos.Count();
                CourseForListDto courseForListDto = new CourseForListDto()
                {
                    CourseName = course.Name,
                    TeacherFullName = course.Teacher.User.FirstName + " " + course.Teacher.User.LastName,
                    Review = course.Review,
                    NumberOfStudent = course.NumberOfStudent,
                    VideoCount = videocount,
                    Price = course.Price

                };
                courseForListDtos.Add(courseForListDto);
            }
            return courseForListDtos;
        }

        public List<CourseForListDto> GetCoursesForStarters()
        {
            using var context = new AppDbContext();
            var courses = context.Courses.ToList();
            List<CourseForListDto> courseForListDtos = new List<CourseForListDto>();
            foreach(var course in courses)
            {
                var lessontitle = context.LessonTitles.FirstOrDefault(lt => lt.CourseId == course.Id);
                var videocount = lessontitle.CourseVideos.Count();
                if (videocount <= 25)
                {
                    CourseForListDto dto = new CourseForListDto()
                    {
                        CourseName = course.Name,
                        TeacherFullName = course.Teacher.User.FirstName + " " + course.Teacher.User.LastName,
                        NumberOfStudent = course.NumberOfStudent,
                        Review = course.Review,
                        VideoCount = videocount,
                        Price = course.Price
                    };
                    courseForListDtos.Add(dto);
                }
            }
            return courseForListDtos;
        }
    }
}
