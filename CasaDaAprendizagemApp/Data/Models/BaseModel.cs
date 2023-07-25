using SQLite;

namespace CasaDaAprendizagemApp.Data.Models
{
    public interface IBaseModel
    {
        int Id { get; set; }
    }

    public abstract class BaseModel : IBaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }

}