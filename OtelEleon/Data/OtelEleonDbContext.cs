using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OtelEleon.Models;
using System.Reflection;
using System.Reflection.Emit;

namespace OtelEleon.Data
{
    public class OtelEleonDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<RoomOtel> RoomOtels { get; set; }
        public DbSet<MigrateCart> MigrateCarts { get; set; }
        public DbSet<ContractOtel> contractOtels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-QHR1LI1\\MSSQLSERVERR;database = Otel; TrustServerCertificate = true; Integrated Security = true; Trusted_Connection = true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			SeedData(builder);
			base.OnModelCreating(builder);
        }
		private void SeedData(ModelBuilder modelBuilder)
		{
            var categoryId1 = Guid.NewGuid();
			var categoryId2 = Guid.NewGuid();
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = categoryId1, Name = "Охуенная", Description = "Вообще охуенная" },
				new Category { Id = categoryId2, Name = "Не охуенная", Description="Вообще не охуенная" }
			);			
		}

	}
}
