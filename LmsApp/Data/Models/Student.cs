using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDaAprendizagemApp.Data.Models
{
    public class Student : Person
    {
        [Indexed]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
