using SQLite;

namespace CasaDaAprendizagemApp.Data.Models
{
    public class CategoryCourse : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Course> CourseList { get; set; }
    }

    public class Course : BaseModel
    {
        [Indexed]
        public int CategoryCourseId { get; set; }
        [Ignore]
        public virtual CategoryCourse CategoryCourse { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Ignore]
        public virtual List<CourseClass> CourseClassList { get; set; }
        [Ignore]
        public virtual List<Topic> TopicList { get; set; }
    }
}
