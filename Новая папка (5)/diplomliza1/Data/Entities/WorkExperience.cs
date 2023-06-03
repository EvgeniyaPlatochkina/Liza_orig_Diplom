using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string SpaseOfWork { get; set; } = null!;
        public string HoursWorked { get; set; } = null!;
        public Questionnare Questionnare { get; set; }

        [NotMapped]
        public string FullWorkExperience { get => $"{SpaseOfWork} {HoursWorked}"; }
    }
}
