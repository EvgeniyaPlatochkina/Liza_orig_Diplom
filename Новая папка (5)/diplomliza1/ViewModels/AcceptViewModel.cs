using diplomliza1.Data;
using diplomliza1.Data.Entities;
using diplomliza1.Services;
using diplomliza1.Storage.Enums;
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
    public class AcceptViewModel : ViewModelBase
    {
        public AcceptViewModel(ApplicationDbContext ctx ,Questionnare questionnare)
        {
            _questionareService = new(ctx);
            _questionnare = questionnare;
        }
        private QuestionareService _questionareService;
        private Questionnare _questionnare;
        private string _dateOfMeeting;
        public string DateOfMeeting { get => _dateOfMeeting; set => Set(ref _dateOfMeeting, value, nameof(DateOfMeeting)); }
        public Questionnare? Questionnare { get => _questionnare; set => Set(ref _questionnare, value, nameof(Questionnare)); }
        private bool FieldsIsNull() =>
           (string.IsNullOrEmpty(DateOfMeeting));
        private void EditQuestionnare()
        {
            if (FieldsIsNull())
                MessageBox.Show($"Укажите дату встречи!", "внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                Questionnare.Status = Statuse.Принято.ToString();
                Questionnare.MeetingDate = DateOfMeeting;
                _questionareService.Update(Questionnare);
                MessageBox.Show($"Обновлено!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           
        }
        public ICommand EditQuestionnareButton => new Command(addreview => EditQuestionnare());
    }
}
