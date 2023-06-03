using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int House { get; set; } = 0!;
        public string Housing { get; set; }

        public string Apartament { get; set; }
        public Staff Staff { get; set; }

        [NotMapped]
        public string FullAdress { get => $"{City} {Street} {House}"; }
    }
}
