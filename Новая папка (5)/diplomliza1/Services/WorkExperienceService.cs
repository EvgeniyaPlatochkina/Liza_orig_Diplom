using diplomliza1.Data.Entities;
using diplomliza1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class WorkExperienceService
    {
        private ApplicationDbContext _ctx;
        public WorkExperienceService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<WorkExperience> GetWorkExperiences()
            => _ctx.WorkExperiences.ToList();
        public WorkExperience? GetLastInNs()
           => _ctx.WorkExperiences.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public WorkExperience? GetINNs(int id)
            => _ctx.WorkExperiences.SingleOrDefault(c => c.Id == id);
        public void Insert(WorkExperience jobTitle)
        {
            _ctx.WorkExperiences.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(WorkExperience jobTitle)
        {
            _ctx.WorkExperiences.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(WorkExperience jobTitle)
        {
            _ctx.WorkExperiences.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
