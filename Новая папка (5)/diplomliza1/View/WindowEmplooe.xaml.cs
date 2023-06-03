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
    /// Логика взаимодействия для WindowEmplooe.xaml
    /// </summary>
    public partial class WindowEmplooe : Window
    {
        private EmployeViewModel _employeViewModel;
        public WindowEmplooe(ApplicationDbContext ctx, User user)
        {
            InitializeComponent();
            DataContext = _employeViewModel = new EmployeViewModel(ctx, user, EmploeePage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _employeViewModel.ExitEmplooeWindow();
        }
    }
}
