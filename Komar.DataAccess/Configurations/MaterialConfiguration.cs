using Komar.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Komar.DataAccess.Configurations
{
    internal class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.ModelNumber).HasMaxLength(100);
            builder.Property(x => x.Size).HasMaxLength(100);
            builder.Property(x => x.Price).HasColumnType("DECIMAL(10, 4)").IsRequired();
            builder.Property(x => x.SalePrice).HasColumnType("DECIMAL(10, 4)").IsRequired();
            builder.Property(x => x.Tax).HasColumnType("DECIMAL(10, 4)").IsRequired();
            builder.Property(x => x.Markup).HasColumnType("DECIMAL(5, 2)").IsRequired();
            builder.HasOne(x => x.Brand).WithMany(x => x.Materials).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Materials).IsRequired();

        }
    }
}
