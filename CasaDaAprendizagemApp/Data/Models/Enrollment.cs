﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDaAprendizagemApp.Data.Models
{
    public class Enrollment
    {
        [Indexed]
        public int StudantId { get; set; }
        public virtual Studant Studant { get; set; }
        [Indexed]
        public int CourseClassId { get; set; }
        public virtual CourseClass CourseClass { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
