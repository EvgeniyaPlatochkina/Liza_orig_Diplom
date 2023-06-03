using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class Passport
    {
        public int Id { get; set; } 
        public int Series { get; set; } = 0!;
        public int Number { get; set; } = 0!;
        public string IssuedBy { get; set; } = null!;
        public string IssuedByDate { get; set; } = null!;
        public string Registration { get; set; } = null!;
        public Staff Staff { get; set; }

        [NotMapped]
        public string FullPassport { get => $"{Series} {Number}"; }
    }
}
