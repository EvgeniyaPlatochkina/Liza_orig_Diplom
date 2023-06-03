using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data.Entities
{
    public class Questionnare
    {


        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; }
        public string Photo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? MeetingDate { get; set; }       
        public string Phone { get; set; } = null!;
        public int? WorkExperienceId { get; set; }
        public int FamilyStatusId { get; set; }
        public int MilitryDutyId { get; set; }
        public int GenderId { get; set; }
        public int JobVacancyId { get; set; }
        public int PlaceOfStudyId { get; set; }
        public FamilyStatus FamilyStatus { get; set; } = null!;
        public MilitryDuty MilitryDuty { get; set; } = null!;
        public Gender Gender { get; set; } = null!;
        public JobVacancy JobVacancy { get; set; } = null!;
        public PlaceOfStudy PlaceOfStudy { get; set; } = null!;
        public WorkExperience? WorkExperience { get; set; } //один к одному
        public int UserId { get; set; }
        public string? Recommendations { get; set; } 
        public string? Skills { get; set; } 
        public string PersonalQualities { get; set;} = null!;
        public string AboutMe { get; set; } = null!;

        public User User { get; set; } = null!;

        [NotMapped]
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }
    }
}
