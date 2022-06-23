using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration
{
    public class TimeLogConfiguration : IEntityTypeConfiguration<TimeLog>
    {
        public void Configure(EntityTypeBuilder<TimeLog> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StartTime).IsRequired();
            builder.Property(p => p.ContractId).IsRequired();

            builder.HasOne(e => e.Contract).WithMany(e => e.TimeLogs).HasForeignKey(e => e.ContractId);
        }
    }
}
