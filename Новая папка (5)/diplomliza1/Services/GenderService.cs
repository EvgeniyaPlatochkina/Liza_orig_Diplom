using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class GenderService
    {
        private ApplicationDbContext _ctx;
        public GenderService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Gender> GetGenders()
            => _ctx.Genders.ToList();
        public Gender? GetLastInNs()
           => _ctx.Genders.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public Gender? GetINNs(int id)
            => _ctx.Genders.SingleOrDefault(c => c.Id == id);
        public void Insert(Gender jobTitle)
        {
            _ctx.Genders.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(Gender jobTitle)
        {
            _ctx.Genders.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(Gender jobTitle)
        {
            _ctx.Genders.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
