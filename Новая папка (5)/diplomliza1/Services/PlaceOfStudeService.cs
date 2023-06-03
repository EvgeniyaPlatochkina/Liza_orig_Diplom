using diplomliza1.Data;
using diplomliza1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class PlaceOfStudeService
    {
        private ApplicationDbContext _ctx;
        public PlaceOfStudeService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<PlaceOfStudy> GetPlaceOfStudy()
            => _ctx.PlaceOfStudys.ToList();
        public PlaceOfStudy? GetLastInNs()
           => _ctx.PlaceOfStudys.ToList().LastOrDefault();


        //var messages = await _companyContext.MESAJLAR.Where(p => p.SENDERID == id || p.SENTID == id).OrderBy(p => p.DATE).GroupBy(p => p.SPECIALID).OrderBy(p => p.XXXXX).Select(p => p.Last()).ToListAsync();
        public PlaceOfStudy? GetINNs(int id)
            => _ctx.PlaceOfStudys.SingleOrDefault(c => c.Id == id);
        public void Insert(PlaceOfStudy jobTitle)
        {
            _ctx.PlaceOfStudys.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(PlaceOfStudy jobTitle)
        {
            _ctx.PlaceOfStudys.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(PlaceOfStudy jobTitle)
        {
            _ctx.PlaceOfStudys.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
