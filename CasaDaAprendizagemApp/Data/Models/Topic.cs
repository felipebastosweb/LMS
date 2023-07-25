using SQLite;


namespace CasaDaAprendizagemApp.Data.Models
{
    public class Topic : BaseModel
    {
        [Indexed]
        public int CourseId { get; set; }
        [Ignore]
        public virtual Course Course { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Ignore]
        public virtual List<Lesson> LessonList { get; set; }

    }
}
