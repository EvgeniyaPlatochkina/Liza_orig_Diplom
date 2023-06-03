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
    public class UserService
    {
        private ApplicationDbContext _ctx;
        public UserService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<User> GetUsers()
            => _ctx.Users
            .Include(pc => pc.Role)
            .ToList();
        public User? GetUsers(int id)
            => _ctx.Users.SingleOrDefault(c => c.Id == id);
        public void Insert(User category)
        {
            _ctx.Users.Add(category);
            _ctx.SaveChanges();
        }
        public void Update(User category)
        {
            _ctx.Users.Update(category);
            _ctx.SaveChanges();
        }
        public void Delete(User category)
        {
            _ctx.Users.Remove(category);
            _ctx.SaveChanges();
        }
    }
}
