using diplomliza1.Controls;
using diplomliza1.Data;
using diplomliza1.Data.Entities;
using diplomliza1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using diplomliza1.ViewModel;
using diplomliza1.Storage.Enums;

namespace diplomliza1.ViewModels
{
    public class QestionnatieViewModel : ViewModelBase
    {

        public QestionnatieViewModel(ApplicationDbContext ctx, JobVacancy jobVacancy,QuestionareService questionareService,User user,WorkExperienceService workExperienceService) 
        {
            _jobVacancy = jobVacancy;
            _user = user;
            _questionareService = new(ctx);
            _placeOfStudeService = new(ctx);
            _educationService = new(ctx);
            _placeOfStudeService = new(ctx);
            _familyStatusService = new(ctx);
            _genderService = new(ctx);
            _militryDutysService = new(ctx);
            _experienceService = workExperienceService;
            DateOfBirth = DateTime.Now;
            UpdateLists();
        }
        private void UpdateLists()
        {
          
            PlaceOfStudys = _placeOfStudeService.GetPlaceOfStudy();
            Educations = _educationService.GetEducation().ToList();
            FamilyStatuse = _familyStatusService.GetFamilyStatus().ToList();
            MilitryDutys = _militryDutysService.GetMilitryDuty().ToList();
            Genders = _genderService.GetGenders().ToList();
            WorkExperiences = _experienceService.GetWorkExperiences();
            Photo = GetPhoto();
        }
        private List<Photo> GetPhoto()
        {
            var list = new List<Photo>();
            list.Add(new Photo(@"\Resources\Pictures\_men.png"));
            list.Add(new Photo(@"\Resources\Pictures\_women.png"));
            return list;
        }
        private User _user;
        private QuestionareService _questionareService;
        private JobVacancy _jobVacancy;
        public JobVacancy SelectedJobVacancy { get => _jobVacancy; set => Set(ref _jobVacancy, value, nameof(SelectedJobVacancy)); }
        private EducationService _educationService;
        private PlaceOfStudeService _placeOfStudeService;
        private WorkExperienceService _experienceService;
        private FamilyStatusService _familyStatusService;
        private GenderService _genderService;
        private MilitryDutysService _militryDutysService;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private JobTitle _selectedJobTitle;
        public JobTitle SelectedJobTitle { get => _selectedJobTitle; set => Set(ref _selectedJobTitle, value, nameof(SelectedJobTitle)); }
        private DateTime _dateOfBirth;

        private string _email;
        private string _phone;
        public DateTime DateOfBirth { get => _dateOfBirth; set => Set(ref _dateOfBirth, value, nameof(DateOfBirth)); }
        public string Email { get => _email; set => Set(ref _email, value, nameof(Email)); }
        public string Phone { get => _phone; set => Set(ref _phone, value, nameof(Phone)); }

        private List<FamilyStatus> _familyStatus;
        private List<MilitryDuty> _militryDuty;
        private List<Gender> _gender;
        private List<PlaceOfStudy> _placeOfStudy;
        private List<WorkExperience> _workExperiences;
        private Questionnare? _questionnare;
        private Photo _selectedphoto;
        public List<WorkExperience> WorkExperiences { get => _workExperiences; set => Set(ref _workExperiences, value, nameof(WorkExperiences)); }
        public List<FamilyStatus> FamilyStatuse { get => _familyStatus; set => Set(ref _familyStatus, value, nameof(FamilyStatuse)); }
        public List<MilitryDuty> MilitryDutys { get => _militryDuty; set => Set(ref _militryDuty, value, nameof(MilitryDutys)); }
        public List<Gender> Genders { get => _gender; set => Set(ref _gender, value, nameof(Genders)); }
        public List<PlaceOfStudy> PlaceOfStudys { get => _placeOfStudy; set => Set(ref _placeOfStudy, value, nameof(PlaceOfStudys)); }
        public Questionnare? Questionnare { get => _questionnare; set => Set(ref _questionnare, value, nameof(Questionnare)); }
        private List<Photo> _photo;
        public List<Photo> Photo { get => _photo; set => Set(ref _photo, value, nameof(Photo)); }

        public Photo SelectedPhoto { get => _selectedphoto; set => Set(ref _selectedphoto, value, nameof(SelectedPhoto)); }

        public string FirstName { get => _firstName; set => Set(ref _firstName, value, nameof(FirstName)); }

        public string LastName { get => _lastName; set => Set(ref _lastName, value, nameof(LastName)); }
        public string MiddleName { get => _middleName; set => Set(ref _middleName, value, nameof(MiddleName)); }

        private FamilyStatus _selectedfamilyStatus;
        private MilitryDuty _selectedmilitryDuty;
        private Gender _selectedgender;
        private PlaceOfStudy _selectedplaceOfStudy;
        private WorkExperience? _selectedWorkExperience;
        public WorkExperience? SelectedWorkExperience { get => _selectedWorkExperience; set => Set(ref _selectedWorkExperience, value, nameof(SelectedWorkExperience)); }
        public FamilyStatus SelectedFamilyStatuse { get => _selectedfamilyStatus; set => Set(ref _selectedfamilyStatus, value, nameof(SelectedFamilyStatuse)); }
        public MilitryDuty SelectedMilitryDutys { get => _selectedmilitryDuty; set => Set(ref _selectedmilitryDuty, value, nameof(SelectedMilitryDutys)); }
        public Gender SelectedGenders { get => _selectedgender; set => Set(ref _selectedgender, value, nameof(SelectedGenders)); }
        public PlaceOfStudy SelectedPlaceOfStudys { get => _selectedplaceOfStudy; set => Set(ref _selectedplaceOfStudy, value, nameof(SelectedPlaceOfStudys)); }
        private string _placyOfStuydeTitle;
        private string _speciality;

        private string? _recommendations;
        private string? _skills;
        private string _personalQualities;
        private string _aboutMe;
       


        private Education _selectedEducation;
        private List<Education> _educations;
        public string PlacyOfStydeTitle { get => _placyOfStuydeTitle; set => Set(ref _placyOfStuydeTitle, value, nameof(PlacyOfStydeTitle)); }
        public string Speciality { get => _speciality; set => Set(ref _speciality, value, nameof(Speciality)); }
        public Education SelectedEducation { get => _selectedEducation; set => Set(ref _selectedEducation, value, nameof(SelectedEducation)); }
        public List<Education> Educations { get => _educations; set => Set(ref _educations, value, nameof(Educations)); }
        private bool PlaceOfStydeIsNull() => (string.IsNullOrEmpty(PlacyOfStydeTitle) || string.IsNullOrEmpty(Speciality) || SelectedEducation == null);
        private void AddPlaceOfStyde()
        {
            if (PlaceOfStydeIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _placeOfStudeService.Insert(new PlaceOfStudy { Title = PlacyOfStydeTitle, Speciality = Speciality, Education = SelectedEducation });
                MessageBox.Show("Резюме добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
            


        }
        public ICommand PlaceOfStydeButton => new Command(addreview => AddPlaceOfStyde());

        private string _spaseOfWork;
        private string _hoursWorked;
        public string SpaseOfWork { get => _spaseOfWork; set => Set(ref _spaseOfWork, value, nameof(SpaseOfWork)); }
        public string HoursWorked { get => _hoursWorked; set => Set(ref _hoursWorked, value, nameof(HoursWorked)); }
        private bool FieldsWorkIsNull() =>
           (string.IsNullOrEmpty(SpaseOfWork)
           || string.IsNullOrEmpty(HoursWorked)  
           );
        private void AddWorkExpirience()
        {
            if(FieldsWorkIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _experienceService.Insert(new WorkExperience { SpaseOfWork = SpaseOfWork, HoursWorked = HoursWorked });
                MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
          


        }
        public ICommand AddWorkExpirienceButton => new Command(addreview => AddWorkExpirience());
        public string? Recommendations { get => _recommendations; set => Set(ref _recommendations, value, nameof(Recommendations)); }
        public string? Skills { get => _skills; set => Set(ref _skills, value, nameof(Skills)); }
        public string PersonalQualities { get => _personalQualities; set => Set(ref _personalQualities, value, nameof(PersonalQualities)); }
        public string AboutMe { get => _aboutMe; set => Set(ref _aboutMe, value, nameof(AboutMe)); }
        private bool FieldsIsNull() =>
            (string.IsNullOrEmpty(FirstName)
            || string.IsNullOrEmpty(LastName)
             || string.IsNullOrEmpty(MiddleName)
            || SelectedPhoto == null!
            || DateOfBirth == null!    
            || string.IsNullOrEmpty(Email)
            ||  string.IsNullOrEmpty(Phone)
            || SelectedMilitryDutys == null!
            || SelectedGenders == null!
            || SelectedPlaceOfStudys == null!
             || string.IsNullOrEmpty(AboutMe)
              || string.IsNullOrEmpty(PersonalQualities)
            );
        private bool SelectedWorkExperienceIsNull() => SelectedWorkExperience == null;
        private void AddQuestionnare()
        {
            if (FieldsIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                if (!SelectedWorkExperienceIsNull())
                {
                    _questionareService.Insert(new Questionnare
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        MiddleName = MiddleName,
                        Photo = SelectedPhoto.Image,
                        DateOfBirth = DateOfBirth,
                        Email = Email,
                        Phone = Phone,
                        Status = Statuse.Рассматривается.ToString(),
                        FamilyStatusId = SelectedFamilyStatuse.Id,
                        MilitryDutyId = SelectedMilitryDutys.Id,
                        GenderId = SelectedGenders.Id,
                        PlaceOfStudyId = SelectedPlaceOfStudys.Id,
                        Recommendations = Recommendations,
                        //MeetingDate = DateTime.Now,
                        Skills = Skills,
                        PersonalQualities = PersonalQualities,
                        AboutMe = AboutMe,
                        JobVacancyId = SelectedJobVacancy.Id,
                        WorkExperienceId = SelectedWorkExperience.Id,
                        UserId = _user.Id

                    }) ;
                    MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateLists();
                }
                else
                {
                    _questionareService.Insert(new Questionnare
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        MiddleName = MiddleName,
                        Photo = SelectedPhoto.Image,
                        DateOfBirth = DateOfBirth,
                        Email = Email,
                        Phone = Phone,
                        Status = Statuse.Рассматривается.ToString(),
                        FamilyStatusId = SelectedFamilyStatuse.Id,
                        MilitryDutyId = SelectedMilitryDutys.Id,
                        GenderId = SelectedGenders.Id,
                        PlaceOfStudyId = SelectedPlaceOfStudys.Id,
                        Recommendations = Recommendations,
             
                        //MeetingDate = DateTime.Now,
                        Skills = Skills,
                        PersonalQualities = PersonalQualities,
                        AboutMe = AboutMe,
                        JobVacancyId = SelectedJobVacancy.Id,
               
                        UserId = _user.Id

                    });
                    MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateLists();
                }
                
            }

        }
            public ICommand AddQuestionnareButton => new Command(addreview => AddQuestionnare());

    }
    
}
