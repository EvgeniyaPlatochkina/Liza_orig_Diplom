using diplomliza1.Data;
using diplomliza1.Data.Entities;
using diplomliza1.Services;
using diplomliza1.View;
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
    public class VacancyPageEmpViewModell : ViewModelBase
    {
        public VacancyPageEmpViewModell(JobVacancyService jobTitleService)
        {
            _jobTitleService = jobTitleService;
           
            UpdateLists();
        }

        private JobVacancyService _jobTitleService;
        private List<JobVacancy> _jobTitles;
        private string _searchJobTitle;
        private JobVacancy _selectedJobTitle;
        public JobVacancy SelectedJobTitle { get => _selectedJobTitle; set => Set(ref _selectedJobTitle, value, nameof(SelectedJobTitle)); }
        public List<JobVacancy> JobTitles { get => _jobTitles; set => Set(ref _jobTitles, value, nameof(JobTitles)); }
        private ICollection<JobVacancy> GetJobTitle() => SearchJobTitle(_jobTitleService.GetJobTitle().ToList());
        private bool SelectedJobTitleIsNull() => SelectedJobTitle == null;
        public string SearchJobTitleValue
        {
            get => _searchJobTitle; set
            {
                if (Set(ref _searchJobTitle, value, nameof(SearchJobTitleValue)))
                    UpdateLists();
            }
        }
        private void UpdateLists()
        {
            JobTitles = new List<JobVacancy>(GetJobTitle());
  
        }
        private void OpenAddJobTitleManagerWindow()
        {
            new VacancyManagerWinodw(null, _jobTitleService).ShowDialog();
            UpdateLists();
        }
        private void OpenEditJobTitleManagerWindow()
        {
            if (!SelectedJobTitleIsNull())
            {
                
                new VacancyManagerWinodw(SelectedJobTitle, _jobTitleService).ShowDialog();
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            UpdateLists();
        }
        private List<JobVacancy> SearchJobTitle(List<JobVacancy> jobTitles)
        {
            if (!string.IsNullOrEmpty(SearchJobTitleValue))
                return jobTitles.Where(p => p.Title.ToLower().Contains(SearchJobTitleValue.ToLower()) || p.Description.ToLower().Contains(SearchJobTitleValue.ToLower())).ToList();
            else
                return jobTitles;
        }
        public void DeleteJobTitle()
        {
            if (!SelectedJobTitleIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _jobTitleService.Delete(SelectedJobTitle);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public ICommand DeleteJobTitleButton => new Command(delete => DeleteJobTitle());

        public ICommand OpenAddManagerWindow => new Command(addquestion => OpenAddJobTitleManagerWindow());
        public ICommand OpenEditManagerWindow => new Command(addquestion => OpenEditJobTitleManagerWindow());
    }
}
