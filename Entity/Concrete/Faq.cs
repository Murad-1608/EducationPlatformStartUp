using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Faq : IEntity
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public bool? Status { get; set; }
    }
}
