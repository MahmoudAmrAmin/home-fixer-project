using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;

namespace Project.DAL.Context
{
    public class DEPIProjectContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DEPIProjectContext(DbContextOptions<DEPIProjectContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L8F2DLS\\SQLEXPRESS;Database=DEPIProjectDB1;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Request>()
           .HasOne(r => r.User)
           .WithMany()
           .HasForeignKey(r => r.UserId)
           .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Specialization)
                .WithMany()
                .HasForeignKey(r => r.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict); 

        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<User> Clients { get; set; }

    }
}
