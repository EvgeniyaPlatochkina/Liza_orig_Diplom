using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class JobVacancyService
    {
        private ApplicationDbContext _ctx;
        public JobVacancyService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICollection<JobVacancy> GetJobTitle()
            => _ctx.JobVacancys.ToList();
        public JobVacancy? GetJobTitle(int id)
            => _ctx.JobVacancys.SingleOrDefault(c => c.Id == id);
        public void Insert(JobVacancy jobTitle)
        {
            _ctx.JobVacancys.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(JobVacancy jobTitle)
        {
            _ctx.JobVacancys.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(JobVacancy jobTitle)
        {
            _ctx.JobVacancys.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
