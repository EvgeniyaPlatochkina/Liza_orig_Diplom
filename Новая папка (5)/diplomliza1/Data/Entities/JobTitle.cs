using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class JobTitle
    {

        public JobTitle()
        {
            Staffs = new List<Staff>();

        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public ICollection<Staff> Staffs { get; set; }
    }
}
