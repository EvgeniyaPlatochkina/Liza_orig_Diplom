using diplomliza1.Controls;
using diplomliza1.Data;
using diplomliza1.Data.Entities;
using diplomliza1.Services;
using diplomliza1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace diplomliza1.ViewModels
{
    public class QuestionnareEditViewModel : ViewModelBase
    { 
        public QuestionnareEditViewModel(ApplicationDbContext ctx,Questionnare? questionnare,QuestionareService questionareService)
        {
            _questionareService = questionareService;
            _placeOfStudeService = new(ctx);
            _educationService = new(ctx);
            _placeOfStudeService = new(ctx);
            _familyStatusService = new(ctx);
            _genderService = new(ctx);
            _militryDutysService = new(ctx);
            _experienceService = new(ctx);
            _vacancyService = new(ctx);
            _questionnare1 = questionnare;
            FirstName = questionnare.FirstName;
            LastName = questionnare.LastName;
            MiddleName = questionnare.MiddleName;
            DateOfBirth = questionnare.DateOfBirth;
            Email = questionnare.Email;
            Phone = questionnare.Phone;
           // JobVacancyId = questionnare.JobVacancyId;
            Recommendations = questionnare.Recommendations;
            Skills = questionnare.Skills;
            AboutMe = questionnare.AboutMe;
            PersonalQualities = questionnare.PersonalQualities;
            SelectedWorkExperience = questionnare.WorkExperience;
            Questionnare = questionnare;
            SelectedGenders = questionnare.Gender;
            SelectedPlaceOfStudys = questionnare.PlaceOfStudy;
            SelectedMilitryDutys = questionnare.MilitryDuty;
            SelectedFamilyStatuse = questionnare.FamilyStatus;
            SelectedWorkExperience = questionnare.WorkExperience;
            Photo = GetPhoto();
            UpdateLists();
            //WorkExperienceId = SelectedWorkExperience.Id
        }
        private void UpdateLists()
        {
            WorkExperiences = _experienceService.GetWorkExperiences();
            PlaceOfStudys = _placeOfStudeService.GetPlaceOfStudy();
            Educations = _educationService.GetEducation().ToList();
            FamilyStatuse = _familyStatusService.GetFamilyStatus().ToList();
            MilitryDutys = _militryDutysService.GetMilitryDuty().ToList();
     
            Genders = _genderService.GetGenders().ToList();
            Photo = GetPhoto();
        }
        private List<Photo> GetPhoto()
        {
            var list = new List<Photo>();
            list.Add(new Photo(@"\Resources\Pictures\_men.png"));
            list.Add(new Photo(@"\Resources\Pictures\_women.png"));
            return list;
        }
        private QuestionareService _questionareService;
        private JobVacancyService _vacancyService;
        private Questionnare _questionnare1;
        private JobVacancy _jobVacancy;
       
        public JobVacancy SelectedJobVacancy { get => _jobVacancy; set => Set(ref _jobVacancy, value, nameof(SelectedJobVacancy)); }
        private EducationService _educationService;
        private PlaceOfStudeService _placeOfStudeService;
        private WorkExperienceService? _experienceService;
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
        public FamilyStatus? SelectedFamilyStatuse { get => _selectedfamilyStatus; set => Set(ref _selectedfamilyStatus, value, nameof(SelectedFamilyStatuse)); }
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
                MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }



        }
        public ICommand PlaceOfStydeButton => new Command(addreview => AddPlaceOfStyde());

        private string _spaseOfWork;
        private string _hoursWorked;
        public string SpaseOfWork { get => _spaseOfWork; set => Set(ref _spaseOfWork, value, nameof(SpaseOfWork)); }
        public string HoursWorked { get => _hoursWorked; set => Set(ref _hoursWorked, value, nameof(HoursWorked)); }

        private void AddWorkExpirience()
        {

            _experienceService.Insert(new WorkExperience { SpaseOfWork = SpaseOfWork, HoursWorked = HoursWorked });
            MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            UpdateLists();


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
            || string.IsNullOrEmpty(Phone)
            || SelectedMilitryDutys == null!
            || SelectedGenders == null!
            || SelectedPlaceOfStudys == null!
             || string.IsNullOrEmpty(AboutMe)
              || string.IsNullOrEmpty(PersonalQualities)
            );
        private bool SelectedWorkExperienceIsNull() => SelectedWorkExperience == null;
    
        
        private void EditQuestionnare()
        {
            if (!FieldsIsNull())
            {
                if (!SelectedWorkExperienceIsNull())
                {
                    Questionnare.FirstName = FirstName;
                    Questionnare.LastName = LastName;
                    Questionnare.MiddleName = MiddleName;
                    Questionnare.DateOfBirth = DateOfBirth;
                    Questionnare.Email = Email;
                    Questionnare.Phone = Phone;
                    Questionnare.Photo = SelectedPhoto.Image;
                    Questionnare.FamilyStatusId = SelectedFamilyStatuse.Id;
                    Questionnare.GenderId = SelectedGenders.Id;
                    Questionnare.JobVacancyId = _questionnare1.JobVacancyId;
                    Questionnare.PlaceOfStudyId = SelectedPlaceOfStudys.Id;
                    Questionnare.MilitryDutyId = SelectedMilitryDutys.Id;
                    Questionnare.Recommendations = Recommendations;
                    Questionnare.Skills = Skills;
                    Questionnare.AboutMe = AboutMe;
                    Questionnare.WorkExperienceId = SelectedWorkExperience.Id;
                    _questionareService.Update(Questionnare);
                    MessageBox.Show($"Обновлено!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    Questionnare.FirstName = FirstName;
                    Questionnare.LastName = LastName;
                    Questionnare.MiddleName = MiddleName;
                    Questionnare.DateOfBirth = DateOfBirth;
                    Questionnare.Email = Email;
                    Questionnare.Phone = Phone;
                    Questionnare.Photo = SelectedPhoto.Image;
                    Questionnare.FamilyStatusId = SelectedFamilyStatuse.Id;
                    Questionnare.GenderId = SelectedGenders.Id;
                    Questionnare.JobVacancyId = _questionnare1.JobVacancyId;
                    Questionnare.PlaceOfStudyId = SelectedPlaceOfStudys.Id;
                    Questionnare.MilitryDutyId = SelectedMilitryDutys.Id;
                    Questionnare.Recommendations = Recommendations;
                    Questionnare.Skills = Skills;
                    Questionnare.AboutMe = AboutMe;
                    Questionnare.WorkExperienceId = null;
                    _questionareService.Update(Questionnare);
                    MessageBox.Show($"Обновлено!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
              
            }
            else
                MessageBox.Show("Заполните поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public ICommand EditQuestionnareButton => new Command(addreview => EditQuestionnare());
    }
}
