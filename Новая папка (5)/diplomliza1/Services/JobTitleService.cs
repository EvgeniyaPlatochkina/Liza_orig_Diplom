using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class JobTitleService
    {
        private ApplicationDbContext _ctx;
        public JobTitleService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICollection<JobTitle> GetJobTitle()
            => _ctx.JobTitles.ToList();
        public JobTitle? GetJobTitle(int id)
            => _ctx.JobTitles.SingleOrDefault(c => c.Id == id);
        public void Insert(JobTitle jobTitle)
        {
            _ctx.JobTitles.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(JobTitle jobTitle)
        {
            _ctx.JobTitles.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(JobTitle jobTitle)
        {
            _ctx.JobTitles.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
