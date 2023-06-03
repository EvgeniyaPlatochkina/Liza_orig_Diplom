﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class MilitryDuty
    {
        public MilitryDuty()
        {
            Staffs = new List<Staff>();
            Questionnares = new HashSet<Questionnare>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Questionnare> Questionnares { get; set; }
    }
}
