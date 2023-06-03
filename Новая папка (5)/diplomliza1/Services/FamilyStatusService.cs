using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class FamilyStatusService
    {
        private ApplicationDbContext _ctx;
        public FamilyStatusService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<FamilyStatus> GetFamilyStatus()
            => _ctx.FamilyStatuses.ToList();
        public FamilyStatus? GetLastInNs()
           => _ctx.FamilyStatuses.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public FamilyStatus? GetINNs(int id)
            => _ctx.FamilyStatuses.SingleOrDefault(c => c.Id == id);
        public void Insert(FamilyStatus jobTitle)
        {
            _ctx.FamilyStatuses.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(FamilyStatus jobTitle)
        {
            _ctx.FamilyStatuses.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(FamilyStatus jobTitle)
        {
            _ctx.FamilyStatuses.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
