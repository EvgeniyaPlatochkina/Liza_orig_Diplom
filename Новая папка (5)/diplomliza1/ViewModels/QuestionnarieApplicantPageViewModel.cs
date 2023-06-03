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
    public class QuestionnarieApplicantPageViewModel : ViewModelBase
    {
        public QuestionnarieApplicantPageViewModel(ApplicationDbContext ctx, QuestionareService questionareService, Questionnare questionnaire)
        {
            _questionareService = questionareService;
            _ctx = ctx;
            _questionnare = questionnaire;
            UpdateLists();
        }
        private ApplicationDbContext _ctx;
        private QuestionareService _questionareService;
        private Questionnare _questionnare;
        private List<Questionnare> _questionnares;
        public List<Questionnare> Questionnares { get => _questionnares; set => Set(ref _questionnares, value, nameof(Questionnares)); }
        private Questionnare _selectedQuestionnares;
        public Questionnare SelectedQuestionnares { get => _selectedQuestionnares; set => Set(ref _selectedQuestionnares, value, nameof(Questionnares)); }
        private ICollection<Questionnare> GetQuestionnare() => _questionareService.GetQuestionnare().ToList();
        private bool SelectedJobTitleIsNull() => SelectedQuestionnares == null;
        public ICommand QuestionnarieApplicantPageButton => new Command(staffpage => OpenInfomationApplicantWindow());
        private void UpdateLists()
        {
            Questionnares = new List<Questionnare>(GetQuestionnare());

        }
        private void OpenInfomationApplicantWindow()
        {
            if (!SelectedJobTitleIsNull())
            {
                new InformationApplicantWindow(_ctx, SelectedQuestionnares).ShowDialog();
                UpdateLists();
            }
            else
                MessageBox.Show("Выберите", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
