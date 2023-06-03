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
    public class VacancuManagerViewModle : ViewModelBase
    {
       public VacancuManagerViewModle(JobVacancy jobTitle,JobVacancyService jobTitleService)
        {
            _jobTitleService = jobTitleService;
            if (jobTitle == null)
            {
                _isNew = true;
                JobTitles = new() { Title = "", Description ="", Earnings =""};
            }
            else
            {
                Title = jobTitle.Title;
                Description = jobTitle.Description;
                Earnings = jobTitle.Earnings;
            }
            JobTitles = jobTitle;

        }

        private JobVacancyService _jobTitleService;
        private string _title;
        private string _description;
        private string _earnings;
        private bool _isNew = false;
        private JobVacancy _jobTitle;

        public JobVacancy JobTitles { get => _jobTitle; set => Set(ref _jobTitle, value, nameof(JobTitles)); }
        public string Title { get => _title; set => Set(ref _title, value, nameof(Title)); }
        public string Description { get => _description; set => Set(ref _description, value, nameof(Description)); }
        public string Earnings { get => _earnings; set => Set(ref _earnings, value, nameof(Earnings)); }

        #region Merthods
        private bool FieldsIsNull() => (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Description) || Earnings == null!);
        private void AddJobTitle()
        {
            if (FieldsIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _jobTitleService.Insert(new JobVacancy { Title = Title, Description = Description, Earnings = Earnings});
                MessageBox.Show("Добавлено!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void EditJobTitle()
        {
            if (!FieldsIsNull())
            {
                JobTitles.Title = Title;
                JobTitles.Description = Description;
                JobTitles.Earnings = Earnings;
                _jobTitleService.Update(JobTitles);
                MessageBox.Show($"Обновлено!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Заполните поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
        #endregion
        #region Commands
        public ICommand AddJobTitleButton => new Command(addreview => AddJobTitle());
        public ICommand EditJobTitleButton => new Command(addreview => EditJobTitle());
 
        #endregion
    }
}
