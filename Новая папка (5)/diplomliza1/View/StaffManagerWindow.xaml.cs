using diplomliza1.Data;
using diplomliza1.Data.Entities;
using diplomliza1.Services;
using diplomliza1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace diplomliza1.View
{
    /// <summary>
    /// Логика взаимодействия для StaffManagerWindow.xaml
    /// </summary>
    public partial class StaffManagerWindow : Window
    {
        public StaffManagerWindow(ApplicationDbContext ctx, Staff? staff, StaffService staffService)
        {
            InitializeComponent();
            var viewModel = new StaffManagerViewModel(ctx, staff, staffService);
            if (staff == null)
            {
                Title = "Создание вопроса";
                ActionButton.Content = "Создать";
                ActionButton.Command = viewModel.AddStaffButton;
            }
            else
            {
                Title = "Редактирование вопроса";
                ActionButton.Content = "Сохранить";
                ActionButton.Command = viewModel.EditStaffButton;
            }
            DataContext = viewModel;
        }
    }
}
