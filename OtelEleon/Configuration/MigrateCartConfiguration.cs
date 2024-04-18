using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OtelEleon.Models;

namespace OtelEleon.Configuration
{
    public class MigrateCartConfiguration : IEntityTypeConfiguration<MigrateCart>
    {
        public void Configure(EntityTypeBuilder<MigrateCart> builder)
        {
            builder.HasKey(mc => mc.ClientId);
            builder.HasOne(mc => mc.Client)
                .WithOne(c => c.MigrateCart)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
