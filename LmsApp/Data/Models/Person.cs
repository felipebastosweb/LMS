using CasaDaAprendizagemApp.Data.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDaAprendizagemApp.Data.Models
{
    public abstract class Person : BaseModel
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        [Indexed]
        public int GenderId { get; set; }
        [Ignore]
        public virtual Gender Gender { get; set; }
    }
}
