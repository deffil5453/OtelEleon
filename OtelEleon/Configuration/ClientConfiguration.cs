using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelEleon.Models;

namespace OtelEleon.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.MigrateCart)
                .WithOne(mc => mc.Client)
                .HasForeignKey<MigrateCart>(mc => mc.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Passport)
                .WithOne(p => p.Client)
                .HasForeignKey<Passport>(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
