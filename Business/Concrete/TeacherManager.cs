using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal teacherDal;
        public TeacherManager(ITeacherDal teacherDal)
        {
            this.teacherDal = teacherDal;
        }

        public void Add(Teacher teacher)
        {
            teacherDal.Add(teacher);
        }

        public IDataResult<List<Teacher>> GetAll()
        {
            var teachers = teacherDal.GetAll();

            return new SuccessDataResult<List<Teacher>>(teachers);
        }
    }
}
