using diplomliza1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using diplomliza1.Data.Entities;

namespace diplomliza1.Services
{
    public class SnilsService
    {
        private ApplicationDbContext _ctx;
        public SnilsService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<SNILS> GetSNILS()
            => _ctx.SNILSs.ToList();
        public SNILS? GetLastInNs()
           => _ctx.SNILSs.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public SNILS? GetINNs(int id)
            => _ctx.SNILSs.SingleOrDefault(c => c.Id == id);
        public void Insert(SNILS jobTitle)
        {
            _ctx.SNILSs.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(SNILS jobTitle)
        {
            _ctx.SNILSs.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(SNILS jobTitle)
        {
            _ctx.SNILSs.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
