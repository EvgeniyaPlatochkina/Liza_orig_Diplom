using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.ViewModels
{
    public class PrintQuestionnareViewModel : ViewModelBase
    {
        public PrintQuestionnareViewModel(ApplicationDbContext ctx, Questionnare questionnare)
        {
            _ctx = ctx;
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

        private Questionnare _questionnare;
        public Questionnare Questionnare { get => _questionnare; set => Set(ref _questionnare, value, nameof(Questionnare)); }
        private string _text;
        private ApplicationDbContext _ctx;
        public string Text
        {
            get { return _text; }
            set => Set(ref _text, value, nameof(Text));
        }
    }
}
