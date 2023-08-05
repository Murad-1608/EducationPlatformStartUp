using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class FaqAnswer : IEntity
    {
        public int Id { get; set; }
        public int FaqId { get; set; }
        public string Answer { get; set; }

        public Faq Faq { get; set; }
    }
}
