using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        void Add(Teacher teacher);
        IDataResult<List<Teacher>> GetAll();
        IDataResult<List<TeacherForHomeDto>> GetAllForHome();
    }
}
