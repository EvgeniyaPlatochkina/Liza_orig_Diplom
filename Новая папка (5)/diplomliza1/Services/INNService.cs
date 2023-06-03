using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class INNService
    {
        private ApplicationDbContext _ctx;
        public INNService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<INN> GetJINNs()
            => _ctx.INNs.ToList();
        public INN? GetLastInNs()
           => _ctx.INNs.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public INN? GetINNs(int id)
            => _ctx.INNs.SingleOrDefault(c => c.Id == id);
        public void Insert(INN jobTitle)
        {
            _ctx.INNs.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(INN jobTitle)
        {
            _ctx.INNs.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(INN jobTitle)
        {
            _ctx.INNs.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
