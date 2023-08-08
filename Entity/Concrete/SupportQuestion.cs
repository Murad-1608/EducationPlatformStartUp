using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class SupportQuestion : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public SupportAnswer? SupportAnswer { get; set; }
    }
}
