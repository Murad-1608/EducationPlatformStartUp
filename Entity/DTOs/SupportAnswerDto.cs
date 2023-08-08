using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class SupportAnswerDto : IDto
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
    }
}
