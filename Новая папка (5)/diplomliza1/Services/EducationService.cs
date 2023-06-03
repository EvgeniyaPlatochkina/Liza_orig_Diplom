using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using diplomliza1.Data;

using diplomliza1.Data.Entities;

namespace diplomliza1.Services
{
    public class EducationService
    {
        private ApplicationDbContext _ctx;
        public EducationService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Education> GetEducation()
            => _ctx.Educations.ToList();
        public Education? GetLastInNs()
           => _ctx.Educations.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public Education? GetINNs(int id)
            => _ctx.Educations.SingleOrDefault(c => c.Id == id);
        public void Insert(Education jobTitle)
        {
            _ctx.Educations.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(Education jobTitle)
        {
            _ctx.Educations.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(Education jobTitle)
        {
            _ctx.Educations.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
