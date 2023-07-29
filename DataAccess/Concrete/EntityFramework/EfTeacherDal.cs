using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTeacherDal : EfRepositoryBase<Teacher, AppDbContext>, ITeacherDal
    {
        public List<TeacherForHomeDto> GetAllForHome()
        {
            using var context = new AppDbContext();

            var teachers = context.Teachers.Include(x => x.User).ToList();

            List<TeacherForHomeDto> teacherForHomeDtos = new List<TeacherForHomeDto>();

            foreach (var item in teachers)
            {
                TeacherForHomeDto dto = new TeacherForHomeDto()
                {
                    Name = $"{item.User.FirstName} {item.User.LastName}",
                    InformationVideo = item.InformationVideo,
                    Instagram = item.Instagram,
                    Tiktok = item.TiktTok,
                    YouTube = item.YouTube,
                };
                teacherForHomeDtos.Add(dto);
            }
            return teacherForHomeDtos;
        }
    }
}
