using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using diplomliza1.Data;
using diplomliza1.Data.Entities;

namespace diplomliza1.Services
{
    public class AddresService
    {
        private ApplicationDbContext _ctx;
        public AddresService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Address> GetAddress()
            => _ctx.Addresses.ToList();
        public Address? GetLastInNs()
           => _ctx.Addresses.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public Address? GetINNs(int id)
            => _ctx.Addresses.SingleOrDefault(c => c.Id == id);
        public void Insert(Address jobTitle)
        {
            _ctx.Addresses.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(Address jobTitle)
        {
            _ctx.Addresses.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(Address jobTitle)
        {
            _ctx.Addresses.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
