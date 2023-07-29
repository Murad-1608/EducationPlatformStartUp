using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        void Add(Teacher teacher);
        IDataResult<List<Teacher>> GetAll();
    }
}
