using Komar.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Komar.DataAccess.Configurations
{
    internal class EmployeeRateConfiguration : IEntityTypeConfiguration<EmployeeRate>
    {
        public void Configure(EntityTypeBuilder<EmployeeRate> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Rate).HasColumnType("DECIMAL(10, 4)").IsRequired();
            builder.HasOne(x => x.EmployeeType).WithMany(x => x.EmployeeRates);

            builder.HasIndex(x => new { x.Name, x.EmployeeTypeId });
        }
    }
}
