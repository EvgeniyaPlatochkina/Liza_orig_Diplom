using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class INN
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public Staff Staff { get; set; }
    }
}
