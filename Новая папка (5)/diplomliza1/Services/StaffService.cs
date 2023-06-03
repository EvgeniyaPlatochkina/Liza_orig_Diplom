using diplomliza1.Data;
using diplomliza1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Services
{
    public class StaffService
    {
        private ApplicationDbContext _ctx;
        public StaffService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICollection<Staff> GetStaff()
            => _ctx.Staffs
          .Include(p => p.Passport)
             .Include(a => a.Address)
             .Include(s => s.SNILS)
             .Include(i => i.INN)
            .Include(f => f.FamilyStatus)
            .Include(m => m.MilitryDuty)
            .Include(g => g.Gender)
            .Include(j => j.JobTitle)
             .Include(p => p.PlaceOfStudy)
            .ThenInclude(p => p.Education)
            .ToList();
        public Staff? GetStaff(int id)
            => _ctx.Staffs
             .Include(i => i.Passport)
             .Include(i => i.Address)
             .Include(i => i.SNILS)
             .Include(i => i.INN)
             .Include(f => f.FamilyStatus)
            .Include(m => m.MilitryDuty)
            .Include(g => g.Gender)
            .Include(j => j.JobTitle)
             .Include(p => p.PlaceOfStudy)
            .ThenInclude(p => p.Education)
            .SingleOrDefault(c => c.Id == id);
        public void Insert(Staff jobTitle)
        {
            _ctx.Staffs.Add(jobTitle);
            _ctx.SaveChanges();
        }
        public void Update(Staff jobTitle)
        {
            _ctx.Staffs.Update(jobTitle);
            _ctx.SaveChanges();
        }
        public void Delete(Staff jobTitle)
        {
            _ctx.Staffs.Remove(jobTitle);
            _ctx.SaveChanges();
        }
    }
}
