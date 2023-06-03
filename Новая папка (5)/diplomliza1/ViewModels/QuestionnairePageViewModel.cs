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
    public class QuestionnairePageViewModel :ViewModelBase
    {

        public QuestionnairePageViewModel(ApplicationDbContext ctx,Questionnare questionnare, QuestionareService questionareService,User user)
        {
            _user = user;
            _questionareService = questionareService;
            _ctx = ctx;
 
            UpdateLists();
        }
        private Questionnare QuestionnaresDate;
        private DateTime date1;
        public DateTime Date1 { get => date1; set => Set(ref date1, value, nameof(Date1)); }
        private string _textDateOfMeeting;
        public string TextDateOfMeeting { get => _textDateOfMeeting; set => Set(ref _textDateOfMeeting, value, nameof(Questionnares)); }
        private ApplicationDbContext _ctx;
        private QuestionareService _questionareService;
        private User _user;
        private List<Questionnare> _questionnares;
        public List<Questionnare> Questionnares { get => _questionnares; set => Set(ref _questionnares, value, nameof(Questionnares)); }

        private Questionnare _selectedQuestionnares;
        public Questionnare SelectedQuestionnares { get => _selectedQuestionnares; set => Set(ref _selectedQuestionnares, value, nameof(Questionnares)); }
        private ICollection<Questionnare> GetQuestionnare() => _questionareService.GetQuestionnare().Where(x=> x.UserId == _user.Id).ToList();

        private void OpenPrintStaffWindow()
        {
            if (!SelectedQuestionnaresIsNull())
            {
                new PrintQuestionnare(_ctx, SelectedQuestionnares).ShowDialog();
                UpdateLists();
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool SelectedQuestionnaresIsNull() => SelectedQuestionnares == null;
        private void UpdateLists()
        {
            Questionnares = new List<Questionnare>(GetQuestionnare());

        }

        private void OpenEditStaffManagerWindow()
        {
            if (!SelectedQuestionnaresIsNull())
            {

                new QuestionnarieEditWindow(_ctx, SelectedQuestionnares, _questionareService).ShowDialog();
                UpdateLists();
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public void DeleteStaff()
        {
            if (!SelectedQuestionnaresIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _questionareService.Delete(SelectedQuestionnares);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public ICommand DeleteStaffButton => new Command(delete => DeleteStaff());
        public ICommand OpenEditManagerWindow => new Command(addquestion => OpenEditStaffManagerWindow());
        public ICommand OpenPrintQuestionButton => new Command(addquestion => OpenPrintStaffWindow());
        
    }
}
