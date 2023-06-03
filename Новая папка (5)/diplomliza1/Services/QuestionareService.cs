using diplomliza1.Data;
using diplomliza1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class QuestionareService
    {
        private ApplicationDbContext _ctx;
        public QuestionareService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Questionnare> GetQuestionnare()
            => _ctx.Questionnares
            .Include(fm =>fm.FamilyStatus)
             .Include(jb => jb.JobVacancy)
             .Include(ml => ml.MilitryDuty)
             .Include(wr => wr.WorkExperience)
             .Include(pl => pl.PlaceOfStudy)
            .ThenInclude(ed =>ed.Education)
             .Include(gr => gr.Gender)
            .ToList();
        public Questionnare? GetRole(int id)
            => _ctx.Questionnares.SingleOrDefault(c => c.Id == id);
        public void Insert(Questionnare role)
        {
            _ctx.Questionnares.Add(role);
            _ctx.SaveChanges();
        }
        public void Update(Questionnare role)
        {
            _ctx.Questionnares.Update(role);
            _ctx.SaveChanges();
        }
        public void Delete(Questionnare role)
        {
            _ctx.Questionnares.Remove(role);
            _ctx.SaveChanges();
        }
    }
}
