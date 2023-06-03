using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class Staff
    {
        

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; }
        public string Photo { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }
        public int? PassportId { get; set; }
        public int AddressId { get; set; }
        public int SNILSId { get; set; }
        public int INNId { get; set; }

        public int FamilyStatusId { get; set; }
        public int MilitryDutyId { get; set; }
        public int GenderId { get; set; }
        public int JobTitleId { get; set; }
        public int PlaceOfStudyId { get; set; }

        public Passport Passport { get; set; } = null!; //один к одному
        public Address Address { get; set; } = null!; //один к одному
        public SNILS SNILS { get; set; } = null!;  //один к одному
        public INN INN { get; set; }  //один к одному
        public FamilyStatus FamilyStatus { get; set; } = null!;
        public MilitryDuty MilitryDuty { get; set; } = null!;
        public Gender Gender { get; set; } = null!;
        public JobTitle JobTitle { get; set; } = null!;
        public PlaceOfStudy PlaceOfStudy { get; set; } = null!;

        [NotMapped]
        public string CorrectPicturePath
        {
            get => (Photo == string.Empty || Photo == null)
                ? @"\Resources\Pictures\NonPicture.png" : @$"\Resources\Pictures\{Photo}";
        }
        [NotMapped]
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }

   

    }
}
