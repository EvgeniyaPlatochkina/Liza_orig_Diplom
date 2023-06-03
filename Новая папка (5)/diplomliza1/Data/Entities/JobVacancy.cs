using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class JobVacancy
    {
        public JobVacancy()
        {
         
            Questionnares = new HashSet<Questionnare>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Earnings { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<Questionnare> Questionnares { get; set; }
    }
}
