using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Spoiler { get; set; }
        public int Review { get; set; }
        public int NumberOfStudent { get; set; }
        public string Language { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public Category Category { get; set; }
        public List<LessonTitle> LessonTitles { get; set; }
    }
}
