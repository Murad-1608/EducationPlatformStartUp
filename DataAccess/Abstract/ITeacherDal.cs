using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Abstract
{
    public interface ITeacherDal : IRepositoryBase<Teacher>
    {
        List<TeacherForHomeDto> GetAllForHome();
    }
}
