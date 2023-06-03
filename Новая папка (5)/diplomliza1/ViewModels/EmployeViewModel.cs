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
using System.Windows.Controls;
using System.Windows.Input;

namespace diplomliza1.ViewModels
{
    public class EmployeViewModel : ViewModelBase
    {
        public EmployeViewModel(ApplicationDbContext ctx, User user, UserControl employePage)
        {

            _jobTitleService = new(ctx);
            _staffService = new(ctx);
            _questionareService = new(ctx);
            _ctx = ctx;
            _client = user;
            EmploeyPage = employePage;

            //OpenMainPage();
        }
        #region Services
        private ApplicationDbContext _ctx;
        private JobVacancyService _jobTitleService;
        private QuestionareService _questionareService;
        private StaffService _staffService;
        private Questionnare _questionnare;
        //private CategoryService _categoryService;
        //private ServiceService _serviceService;
        //private ProductOrderService _productOrderService;
        //private ServiceOrderService _serviceOrderService;
        //private QuestionService _questionService;
        //private NewsService _newsService;
        //private ReviewService _reviewService;
        //private ClientService _clientService;
        #endregion
        private User _client;
        private UserControl _employePage;

        public UserControl EmploeyPage { get => _employePage; set => Set(ref _employePage, value, nameof(EmploeyPage)); }
        //private void OpenMainPage() => EmploeyPage.Content = new MainPage(_client, _productService, _categoryService, _serviceService, _productOrderService, _serviceOrderService);
        private void OpenJopTilePage() => EmploeyPage.Content = new VacancyPageEmpl(_jobTitleService);
        private void OpenStaffPage() => EmploeyPage.Content = new StaffPage(_ctx,_staffService);

        //private void OpenQuestionsPage() => EmploeyPage.Content = new QuestionsPage(_client, _questionService);
        //private void OpenNewsPage() => EmploeyPage.Content = new NewsPage(_newsService);
        //private void OpenAboutUsPage() => EmploeyPage.Content = new AboutUsPage();
        //private void OpenReviewsPage() => EmploeyPage.Content = new ReviewsPage(_client, _reviewService);
        //private void OpenAccountPage() => EmploeyPage.Content = new AccountPage(_client, _clientService);

        public void ExitEmplooeWindow()
        {
            new MainWindow().Show();
            var CurrentWindow = Application.Current.MainWindow;
            CurrentWindow.Close();
        }
        #region Commands
        public ICommand JobTitlePageButton => new Command(JopTilepage => OpenJopTilePage());
        public ICommand StaffPageButton => new Command(staffpage => OpenStaffPage());
        private void OpenuestionnarieApplicantPage() => EmploeyPage.Content = new QuestionnarieApplicantPage(_ctx, _questionareService, _questionnare);
        public ICommand QuestionnarieApplicantPageButton => new Command(staffpage => OpenuestionnarieApplicantPage());
        //public ICommand HistoryPageButton => new Command(historypage => OpenHistoryPage());
        //public ICommand QuestionsPageButton => new Command(employeepage => OpenQuestionsPage());
        //public ICommand NewsPageButton => new Command(newspage => OpenNewsPage());
        //public ICommand AboutUsPageButton => new Command(aboutuspage => OpenAboutUsPage());
        //public ICommand ReviewsPageButton => new Command(reviewspage => OpenReviewsPage());
        //public ICommand AccountPageButton => new Command(accountpage => OpenAccountPage());
        //public ICommand LogOutButton => new Command(logout => LogOut());
        #endregion
    }
}
