using Komar.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Komar.DataAccess.Configurations
{
    internal class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
