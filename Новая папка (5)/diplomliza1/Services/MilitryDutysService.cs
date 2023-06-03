using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class MilitryDutysService
    {
        private ApplicationDbContext _ctx;
        public MilitryDutysService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICollection<MilitryDuty> GetMilitryDuty()
            => _ctx.MilitryDuties.ToList();
        public MilitryDuty? GetJobTitle(int id)
            => _ctx.MilitryDuties.SingleOrDefault(c => c.Id == id);
        public void Insert(MilitryDuty jobTitle)
        {
            _ctx.MilitryDuties.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(MilitryDuty jobTitle)
        {
            _ctx.MilitryDuties.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(MilitryDuty jobTitle)
        {
            _ctx.MilitryDuties.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
