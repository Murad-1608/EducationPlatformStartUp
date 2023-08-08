using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class GetSupportAnswer : IDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
