using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class PassportService
    {
        private ApplicationDbContext _ctx;
        public PassportService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Passport> GetPassports()
            => _ctx.Passports.ToList();
        public Passport? GetLastInNs()
           => _ctx.Passports.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public Passport? GetINNs(int id)
            => _ctx.Passports.SingleOrDefault(c => c.Id == id);
        public void Insert(Passport jobTitle)
        {
            _ctx.Passports.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(Passport jobTitle)
        {
            _ctx.Passports.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(Passport jobTitle)
        {
            _ctx.Passports.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
