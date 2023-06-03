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
    public  class StaffPageViewModel : ViewModelBase
    {
        public StaffPageViewModel(ApplicationDbContext ctx, StaffService staffService)
        {
            _staffService = staffService;
            _ctx = ctx;
            UpdateLists();
        }

        private ApplicationDbContext _ctx;
        private StaffService _staffService;
        private List<Staff> _staff;
        private string _searchStaff;
        private Staff _selectedStaff;
        private Staff _staffs;
        public Staff SelectedStaff { get => _selectedStaff; set => Set(ref _selectedStaff, value, nameof(SelectedStaff)); }
        public List<Staff> Staffs { get => _staff; set => Set(ref _staff, value, nameof(Staffs)); }
        private ICollection<Staff> GetStaff() => SearchStaff(_staffService.GetStaff().ToList());
        private void OpenPrintStaffWindow()
        {
            if (!SelectedJobTitleIsNull())
            {
                new PrintStaff(_ctx, SelectedStaff).ShowDialog();
                UpdateLists();
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool SelectedJobTitleIsNull() => SelectedStaff == null;
        public string SearchStaffValue
        {
            get => _searchStaff; set
            {
                if (Set(ref _searchStaff, value, nameof(SearchStaffValue)))
                    UpdateLists();
            }
        }
        private void UpdateLists()
        {
            Staffs = new List<Staff>(GetStaff());
        }
        private void OpenAddStaffManagerWindow()
        {
            new StaffManagerWindow(_ctx, null, _staffService).ShowDialog();
            UpdateLists();
        }
        private void OpenEditStaffManagerWindow()
        {
            if (!SelectedJobTitleIsNull())
            {

                new StaffManagerWindow(_ctx, SelectedStaff, _staffService).ShowDialog();
                UpdateLists();
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }
        private List<Staff> SearchStaff(List<Staff> jobTitles)
        {
            if (!string.IsNullOrEmpty(SearchStaffValue))
                return jobTitles.Where(p => p.FirstName.ToLower().Contains(SearchStaffValue.ToLower()) || p.LastName.ToLower().Contains(SearchStaffValue.ToLower())).ToList();
            else
                return jobTitles;
        }
        public void DeleteStaff()
        {
            if (!SelectedJobTitleIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _staffService.Delete(SelectedStaff);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public ICommand DeleteStaffButton => new Command(delete => DeleteStaff());

        public ICommand OpenAddManagerWindow => new Command(addquestion => OpenAddStaffManagerWindow());
        public ICommand OpenEditManagerWindow => new Command(addquestion => OpenEditStaffManagerWindow());

        public ICommand OpenPrintStaffButton => new Command(addquestion => OpenPrintStaffWindow());
        
    }
}
