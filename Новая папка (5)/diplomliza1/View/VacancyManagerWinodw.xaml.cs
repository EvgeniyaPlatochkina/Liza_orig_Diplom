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
    /// Логика взаимодействия для VacancyManagerWinodw.xaml
    /// </summary>
    public partial class VacancyManagerWinodw : Window
    {
        public VacancyManagerWinodw(JobVacancy jobTitle, JobVacancyService  jobTitleService)
        {
            InitializeComponent();
            var viewModel = new VacancuManagerViewModle(jobTitle, jobTitleService);
            if (jobTitle == null)
            {
                Title = "Создание вопроса";
                ActionButton.Content = "Создать";
                ActionButton.Command = viewModel.AddJobTitleButton;
            }
            else
            {
                Title = "Редактирование вопроса";
                ActionButton.Content = "Сохранить";
                ActionButton.Command = viewModel.EditJobTitleButton;
            }
            DataContext = viewModel;
        }
    }
}
