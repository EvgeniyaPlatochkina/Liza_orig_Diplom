using diplomliza1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplomliza1.Data
{

    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        private const string connectionString = @"Server = localhost\SQLEXPRESS; Database=DIPLOM_LIZA; Trusted_Connection=true; TrustServerCertificate=true;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Education> Educations { get; set; } = null!;
        public DbSet<FamilyStatus> FamilyStatuses { get; set; } = null!;
        public DbSet<PlaceOfStudy> PlaceOfStudys { get; set; } = null!;
        public DbSet<Gender> Genders { get; set; } = null!;
        public DbSet<INN> INNs { get; set; } = null!;
        public DbSet<JobVacancy> JobVacancys{ get; set; } = null!;
        public DbSet<JobTitle> JobTitles { get; set; } = null!;
        public DbSet<MilitryDuty> MilitryDuties { get; set; } = null!;
        public DbSet<Passport> Passports { get; set; } = null!;
        public DbSet<Questionnare> Questionnares { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<SNILS> SNILSs { get; set; } = null!;
        public DbSet<Staff> Staffs { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<WorkExperience> WorkExperiences { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Passport>()
            //    .HasOne(p => p.Staff)
            //    .WithOne(u => u.Passport)
            //    .HasForeignKey<Passport>
            //    (c => c.Id);

            //modelBuilder.Entity<INN>()
            //  .HasOne(p => p.Staff)
            //  .WithOne(u => u.INN)
            //  .HasForeignKey<INN>
            //  (c => c.Id);

            //modelBuilder.Entity<SNILS>()
            //  .HasOne(p => p.Staff)
            //  .WithOne(u => u.SNILS)
            //  .HasForeignKey<SNILS>
            //  (c => c.Id);

            //modelBuilder.Entity<Address>()
            //  .HasOne(p => p.Staff)
            //  .WithOne(u => u.Address)
            //  .HasForeignKey<Address>
            //  (c => c.Id);

            //modelBuilder.Entity<WorkExperience>()
            //  .HasOne(p => p.Questionnare)
            //  .WithOne(u => u.WorkExperience)
            //  .HasForeignKey<WorkExperience>
            //  (c => c.Id);

            //base.OnModelCreating(modelBuilder);
        }
        



    }
}
