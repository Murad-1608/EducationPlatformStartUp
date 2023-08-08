using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class SupportAnswer : IEntity
    {
        public int Id { get; set; }
        public int SupportQuestionId { get; set; }
        public string Content { get; set; }

        public SupportQuestion SupportQuestion { get; set; }
    }
}
