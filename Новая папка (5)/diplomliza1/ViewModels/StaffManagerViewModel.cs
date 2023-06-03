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
using System.Windows.Controls;
using System.Windows.Input;

namespace diplomliza1.ViewModels
{
    public class StaffManagerViewModel : ViewModelBase
    {
        public StaffManagerViewModel(ApplicationDbContext ctx, Staff? staff, StaffService staffService)
        {
           
            if (staff == null)
            {
                _isNew = true;
            }
            else
            {
                FirstName = staff.FirstName;
                LastName = staff.LastName;
                MiddleName = staff.MiddleName;
                DateOfBirth = staff.DateOfBirth;
                EnrollmentDate = staff.EnrollmentDate;
                Email = staff.Email;
                Phone = staff.Phone;
                SelectedPassports = staff.Passport;
                SelectedAddress = staff.Address;
                SelectedFamilyStatuse = staff.FamilyStatus;
                SelectedGenders = staff.Gender;
                SelectedINNS = staff.INN;
                SekectedSNILS = staff.SNILS;
                SelectedJobTitle = staff.JobTitle;
                SelectedPlaceOfStudys = staff.PlaceOfStudy;
                SelectedMilitryDutys = staff.MilitryDuty;
            }
            _staffService = staffService;
            _iNNService = new(ctx);
            _jobTitleService = new(ctx);
            _passportService = new(ctx);
            _addresService = new(ctx);
            _snilsService = new(ctx);
            _educationService = new(ctx);
            _placeOfStudeService = new(ctx);
            _snilsService = new(ctx);
            _familyStatusService = new(ctx);
            _genderService = new(ctx);
            _militryDutysService = new(ctx);
            DateOfBirth = DateTime.Now;
            EnrollmentDate = DateTime.Now;
            Staffs = staff;
            UpdateLists();
        }
        private bool FieldsIsNull() =>
            (string.IsNullOrEmpty(FirstName)
            || string.IsNullOrEmpty(LastName)
            || string.IsNullOrEmpty(MiddleName)
            || SelectedPhoto == null!
            || DateOfBirth == null!
            || EnrollmentDate == null!
            || string.IsNullOrEmpty(Email)
            || string.IsNullOrEmpty(Phone)
            || SelectedPassports == null!
            || SelectedFamilyStatuse == null!
            || SelectedAddress == null!
            || SekectedSNILS == null!
            || SelectedINNS == null!
            || SelectedJobTitle == null!
            || SelectedMilitryDutys == null!
            || SelectedGenders == null!
            || SelectedPlaceOfStudys == null!
            );
        private void UpdateLists()
        {
            INNS = _iNNService.GetJINNs();
            PlaceOfStudys = _placeOfStudeService.GetPlaceOfStudy();
            Educations = _educationService.GetEducation().ToList();
            Passports = _passportService.GetPassports().ToList();
            FamilyStatuse = _familyStatusService.GetFamilyStatus().ToList();
            MilitryDutys = _militryDutysService.GetMilitryDuty().ToList();
            Genders = _genderService.GetGenders().ToList();
            Address = _addresService.GetAddress().ToList();
            SNILs = _snilsService.GetSNILS().ToList();
            Passports = _passportService.GetPassports();
            JobTitles = _jobTitleService.GetJobTitle().ToList();
            Photo = GetPhoto();
        }
        private StaffService _staffService;
        private INNService _iNNService;
        private JobTitleService _jobTitleService;
        private PassportService _passportService;
        private AddresService _addresService;
        private SnilsService _snilsService;
        private EducationService _educationService;
        private PlaceOfStudeService _placeOfStudeService;
        private FamilyStatusService _familyStatusService;
        private GenderService _genderService;
        private MilitryDutysService _militryDutysService;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _description;
        private int _earnings;
        private bool _isNew = false;
        private Staff? _staff;


       

       


        private Photo _selectedphoto;
        private string _titleINN;
        public string TitleINN { get => _titleINN; set => Set(ref _titleINN, value, nameof(TitleINN)); }

        private List<INN> _inn;
        public List<INN> INNS { get => _inn; set => Set(ref _inn, value, nameof(INNS)); }



        //private INN _innId;
        //public INN INNSId { get => _innId; set => Set(ref _innId, value, nameof(INNSId)); }

        private INN _selectedinn;
        public INN SelectedINNS { get => _selectedinn; set => Set(ref _selectedinn, value, nameof(SelectedINNS)); }


        private List<JobTitle> _jobTitles;
        public List<JobTitle> JobTitles { get => _jobTitles; set => Set(ref _jobTitles, value, nameof(JobTitles)); }

        private JobTitle _selectedJobTitle;
        public JobTitle SelectedJobTitle { get => _selectedJobTitle; set => Set(ref _selectedJobTitle, value, nameof(SelectedJobTitle)); }

        private List<FamilyStatus> _familyStatus;
        private List<MilitryDuty> _militryDuty;
        private List<Gender> _gender;
        private List<PlaceOfStudy> _placeOfStudy;
        private List<Passport> _passport;
        private List<SNILS> _sNILS;
        private List<Address> _address;

        public List<Address> Address { get => _address; set => Set(ref _address, value, nameof(Address)); }
        public List<SNILS> SNILs { get => _sNILS; set => Set(ref _sNILS, value, nameof(SNILs)); }
        public List<Passport> Passports { get => _passport; set => Set(ref _passport, value, nameof(Passports)); }
        public List<FamilyStatus> FamilyStatuse { get => _familyStatus; set => Set(ref _familyStatus, value, nameof(FamilyStatuse)); }
        public List<MilitryDuty> MilitryDutys { get => _militryDuty; set => Set(ref _militryDuty, value, nameof(MilitryDutys)); }
        public List<Gender> Genders { get => _gender; set => Set(ref _gender, value, nameof(Genders)); }
        public List<PlaceOfStudy> PlaceOfStudys { get => _placeOfStudy; set => Set(ref _placeOfStudy, value, nameof(PlaceOfStudys)); }

        private FamilyStatus _selectedfamilyStatus;
        private MilitryDuty _selectedmilitryDuty;
        private Gender _selectedgender;
        private PlaceOfStudy _selectedplaceOfStudy;
        private Passport _selectedpassport;
        private Address _selectedaddress;
        private SNILS _selectedSNILS;


        private DateTime _enrollmentDate;
        private DateTime _dateOfBirth;
     
        private string _email;
        private string _phone;
        public DateTime DateOfBirth { get => _dateOfBirth; set => Set(ref _dateOfBirth, value, nameof(DateOfBirth)); }
        public string Email { get => _email; set => Set(ref _email, value, nameof(Email)); }
        public string Phone { get => _phone; set => Set(ref _phone, value, nameof(Phone)); }
        public DateTime EnrollmentDate { get => _enrollmentDate; set => Set(ref _enrollmentDate, value, nameof(EnrollmentDate)); }

        public Staff? Staffs { get => _staff; set => Set(ref _staff, value, nameof(Staffs)); }
        private List<Photo> _photo;
        public List<Photo> Photo { get => _photo; set => Set(ref _photo, value, nameof(Photo)); }

        public Photo SelectedPhoto { get => _selectedphoto; set => Set(ref _selectedphoto, value, nameof(SelectedPhoto)); }

        public string FirstName { get => _firstName; set => Set(ref _firstName, value, nameof(FirstName)); }

        public string LastName { get => _lastName; set => Set(ref _lastName, value, nameof(LastName)); }
        public string MiddleName { get => _middleName; set => Set(ref _middleName, value, nameof(MiddleName)); }



        #region Merthods
        
        private bool ClientIsExist() => _staffService.GetStaff().Any(c => c.FirstName== FirstName && c.LastName == LastName && c.MiddleName == MiddleName);
        private bool INNSAlredyInUse() => _staffService.GetStaff().Any(c => c.INN == SelectedINNS);
        private bool PassportsAlredyInUse() => _staffService.GetStaff().Any(c => c.Passport == SelectedPassports);
        private bool SnilsAlredyInUse() => _staffService.GetStaff().Any(c => c.SNILS == SekectedSNILS);
        //private bool PassportIsNull() => (INNS.Id == null);

        public SNILS SekectedSNILS { get => _selectedSNILS; set => Set(ref _selectedSNILS, value, nameof(SekectedSNILS)); }
        public Address SelectedAddress { get => _selectedaddress; set => Set(ref _selectedaddress, value, nameof(SelectedAddress)); }
        public Passport SelectedPassports { get => _selectedpassport; set => Set(ref _selectedpassport, value, nameof(SelectedPassports)); }
        public FamilyStatus SelectedFamilyStatuse { get => _selectedfamilyStatus; set => Set(ref _selectedfamilyStatus, value, nameof(SelectedFamilyStatuse)); }
        public MilitryDuty SelectedMilitryDutys { get => _selectedmilitryDuty; set => Set(ref _selectedmilitryDuty, value, nameof(SelectedMilitryDutys)); }
        public Gender SelectedGenders { get => _selectedgender; set => Set(ref _selectedgender, value, nameof(SelectedGenders)); }
        public PlaceOfStudy SelectedPlaceOfStudys { get => _selectedplaceOfStudy; set => Set(ref _selectedplaceOfStudy, value, nameof(SelectedPlaceOfStudys)); }

        private void EditStaff()
        {
            if (!FieldsIsNull())

            {
                Staffs.FirstName = FirstName;
                Staffs.LastName = LastName;
                Staffs.MiddleName = MiddleName;
                Staffs.DateOfBirth = DateOfBirth;
                Staffs.EnrollmentDate = EnrollmentDate;
                Staffs.Email = Email;
                Staffs.Phone = Phone;
                Staffs.PassportId = SelectedPassports.Id;
                Staffs.Photo = SelectedPhoto.Image;
                Staffs.AddressId = SelectedAddress.Id;
                Staffs.FamilyStatusId = SelectedFamilyStatuse.Id;
                Staffs.GenderId = SelectedGenders.Id;
                Staffs.INNId = SelectedINNS.Id;
                Staffs.JobTitleId = SelectedJobTitle.Id;
                Staffs.PlaceOfStudyId = SelectedPlaceOfStudys.Id;
                Staffs.MilitryDutyId = SelectedMilitryDutys.Id;
                _staffService.Update(Staffs);
                MessageBox.Show($"Обновлено!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Заполните поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void AddStaff()
        {
            if (FieldsIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (ClientIsExist())
                MessageBox.Show("Используйте другой  ФИО!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (PassportsAlredyInUse())
                MessageBox.Show("Используйте другой Паспорт", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (SnilsAlredyInUse())
                MessageBox.Show("Используйте другой Снилс", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (INNSAlredyInUse())
                MessageBox.Show("Используйте другой ИНН", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _staffService.Insert(new Staff
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    MiddleName = MiddleName,
                    Photo = SelectedPhoto.Image,
                    DateOfBirth = DateOfBirth,
                    Email = Email,
                    Phone = Phone,
                    EnrollmentDate = EnrollmentDate,
                    PassportId = SelectedPassports.Id,
                    AddressId = SelectedAddress.Id,
                    SNILSId = SekectedSNILS.Id,
                    INNId = SelectedINNS.Id,
                    JobTitleId = SelectedJobTitle.Id,
                    FamilyStatusId = SelectedFamilyStatuse.Id,
                    MilitryDutyId = SelectedMilitryDutys.Id,
                    GenderId = SelectedGenders.Id,
                    PlaceOfStudyId = SelectedPlaceOfStudys.Id,
                });
                MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();

            }
        }
        private bool INNFieldsIsNull() =>
          (string.IsNullOrEmpty(TitleINN)
          );
        private bool AddINNSAlredyInUse() => _iNNService.GetJINNs().Any(c => c.Title == TitleINN);
        private void AddINN()
        {
            if (INNFieldsIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (AddINNSAlredyInUse())
                MessageBox.Show("Используйте другой логин и пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _iNNService.Insert(new INN { Title = TitleINN });
                MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }


        }
        private int _serias;
        private int _number;
        private string _issuedBy ;
        private string _issuedByDate;
        private string _registration;
        public int Series { get => _serias; set => Set(ref _serias, value, nameof(Series)); }
        public int Number { get => _number; set => Set(ref _number, value, nameof(Number)); }
        public string IssuedBy { get => _issuedBy; set => Set(ref _issuedBy, value, nameof(IssuedBy)); }
        public string IssuedByDate { get => _issuedByDate; set => Set(ref _issuedByDate, value, nameof(IssuedByDate)); }
        public string Registration { get => _registration; set => Set(ref _registration, value, nameof(Registration)); }

        private bool PassportFieldsIsNull() =>
            (string.IsNullOrEmpty(IssuedBy)
            || string.IsNullOrEmpty(IssuedByDate)
              || string.IsNullOrEmpty(IssuedByDate)
            || string.IsNullOrEmpty(Registration) 
            || Series == 0!
             || Number == 0!
     );
        private bool SeriaNumberIsExist() => _passportService.GetPassports().Any(c => c.Series == Series && c.Number == Number);
        private bool SeriaAlredyInUse() => _passportService.GetPassports().Any(c => c.Series == Series);
        private bool SeriaNumberAlredyInUse() => _passportService.GetPassports().Any(c => c.Number == Number);
        private void AddPassport()
        {
            if (PassportFieldsIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (SeriaNumberIsExist())
                MessageBox.Show("Используйте другой логин и пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (SeriaAlredyInUse())
                MessageBox.Show("Используйте другой логин и пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (SeriaNumberAlredyInUse())
                MessageBox.Show("Используйте другой логин и пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _passportService.Insert(new Passport { Series = Series, Number = Number, IssuedBy = IssuedBy, IssuedByDate = IssuedByDate, Registration = Registration });
                MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
           

        }
        private int _house;
        private string _housing;
        private string _region;
        private string _city;
        private string _postalCode;
        private string _street;
        private string _apartament;
        public int House { get => _house; set => Set(ref _house, value, nameof(House)); }
        public string Housing { get => _housing; set => Set(ref _housing, value, nameof(Housing)); }
        public string Region { get => _region; set => Set(ref _region, value, nameof(Region)); }
        public string City { get => _city; set => Set(ref _city, value, nameof(City)); }
        public string PostalCode { get => _postalCode; set => Set(ref _postalCode, value, nameof(PostalCode)); }
        public string Street { get => _street; set => Set(ref _street, value, nameof(Street)); }

        public string Apartament { get => _apartament; set => Set(ref _apartament, value, nameof(Apartament)); }

        private bool AdressFieldsIsNull() =>
           (string.IsNullOrEmpty(Region)
           || string.IsNullOrEmpty(City)
             || string.IsNullOrEmpty(PostalCode)
           || string.IsNullOrEmpty(Street)
           || House == 0!
    );
        private void AddAdress()
        {
            if (AdressFieldsIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _addresService.Insert(new Address { House = House, Housing = Housing, Region = Region, City = City, PostalCode = PostalCode, Street = Street, Apartament = Apartament });
                MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
           

        }
        private string _snilsTitle;
        public string SnilsTile { get => _snilsTitle; set => Set(ref _snilsTitle, value, nameof(SnilsTile)); }
        private bool SnilsIsNull() => string.IsNullOrEmpty(SnilsTile);
        private void AddSnils()
        {
            if (SnilsIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _snilsService.Insert(new SNILS { Title = SnilsTile });
                MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
           

        }
        private string _placyOfStuydeTitle;
        private string _speciality;
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
        public ICommand AddStaffButton => new Command(addreview => AddStaff());
        public ICommand EditStaffButton => new Command(addreview => EditStaff());
        public ICommand PlaceOfStydeButton => new Command(addreview => AddPlaceOfStyde());

        public ICommand AddJobTitleButton => new Command(addreview => AddINN());
        public ICommand AddPassportButton => new Command(addreview => AddPassport());
        public ICommand AddAdressButton => new Command(addreview => AddAdress());
        public ICommand AddSnilsButton => new Command(addreview => AddSnils());
        
        //private void EditJobTitle()
        //{
        //    if (!FieldsIsNull())
        //    {
        //        JobTitles.Title = Title;
        //        JobTitles.Description = Description;
        //        JobTitles.Earnings = Earnings;
        //        _jobTitleService.Update(JobTitles);
        //        MessageBox.Show($"Вопрос обновлён!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    else
        //        MessageBox.Show("Заполните поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
        //}
        private List<Photo> GetPhoto()
        {
            var list = new List<Photo>();
            list.Add(new Photo(@"\Resources\Pictures\_men.png" ));
            list.Add(new Photo(@"\Resources\Pictures\_women.png"));
            return list;
        }
        #endregion
        #region Commands
        //public ICommand AddJobTitleButton => new Command(addreview => AddJobTitle());
        //public ICommand EditJobTitleButton => new Command(addreview => EditJobTitle());

        #endregion
    }
}
