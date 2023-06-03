using diplomliza1.Data;
using diplomliza1.Data.Entities;
using diplomliza1.Services;
using diplomliza1.Storage.Enums;
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
    public class InformationApplicantViewModel : ViewModelBase
    {
        public InformationApplicantViewModel(ApplicationDbContext ctx, Questionnare questionnare, InformationApplicantWindow informationApplicantWindow)
        {
            _ctx = ctx;
            _questionareService = new(_ctx);
            Questionnare = questionnare;
            if (questionnare.WorkExperience == null)
            {
                Text = "Не работал";
            }
            else
            {
                Text = questionnare.WorkExperience.FullWorkExperience;
            }
        }

        private string _text;
        private ApplicationDbContext _ctx;
        public string Text
        {
            get { return _text; }
            set=> Set(ref _text, value, nameof(Text));
        }


        private Questionnare _questionnare;
        private QuestionareService _questionareService;
        public Questionnare Questionnare { get => _questionnare; set => Set(ref _questionnare, value, nameof(Questionnare)); }
        private void OpenAcceptWindow()
        {
            new AcceptApplicantWindow(_ctx,Questionnare).ShowDialog();

        }
        private void RejectQuestionnare()
        {
            Questionnare.Status = Statuse.Отколено.ToString();
            _questionareService.Update(Questionnare);
            MessageBox.Show($"Успешно отклонено!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public ICommand RejectQuestionnareButton => new Command(addreview => RejectQuestionnare());
        public ICommand OpenAcceptApplicantWindow => new Command(addquestion => OpenAcceptWindow());
    }
}
