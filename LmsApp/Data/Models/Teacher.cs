using SQLite;

namespace CasaDaAprendizagemApp.Data.Models
{
    public class Teacher : Person
    {
        [Indexed]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
