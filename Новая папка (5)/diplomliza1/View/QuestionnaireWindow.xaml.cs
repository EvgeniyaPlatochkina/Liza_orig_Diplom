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
    /// Логика взаимодействия для QuestionnaireWindow.xaml
    /// </summary>
    public partial class QuestionnaireWindow : Window
    {
        public QuestionnaireWindow(ApplicationDbContext ctx,JobVacancy jobTitle, JobVacancyService jobTitleService,QuestionareService questionareService,User user, WorkExperienceService workExperienceService)
        {
            InitializeComponent();
            DataContext = new QestionnatieViewModel(ctx,jobTitle, questionareService, user, workExperienceService);
        }
    }
}
