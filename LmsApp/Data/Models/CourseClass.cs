using SQLite;

namespace CasaDaAprendizagemApp.Data.Models
{
    public class CourseClass : BaseModel
    {
        [Indexed]
        public int CourseId { get; set; }
        [Ignore]
        public virtual Course Course { get; set; }
        [Ignore]
        public virtual List<Enrollment> EnrollmentList { get; set; }
        [Indexed]
        public int TeacherId { get; set; }
        [Ignore]
        public virtual Teacher Teacher { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime FinishDate { get; set; } = DateTime.Now.AddDays(7);
        public DateTime CreationDate { get; set;} = DateTime.Now;
    }
}
