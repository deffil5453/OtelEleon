using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelEleon.Models;

namespace OtelEleon.Configuration
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.HasKey(p => p.ClientId);
            builder.HasOne(mc => mc.Client)
                .WithOne(c => c.Passport)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
