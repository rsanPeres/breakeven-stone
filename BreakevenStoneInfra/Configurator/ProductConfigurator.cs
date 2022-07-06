using BreakevenStoneDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakevenStoneInfra
{
    public class ProductConfigurator : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder
                .ToTable("Product");
            builder
                .Property(p => p.Id)
                .HasColumnName("Id_Product");
            builder
                .Property(p => p.DateIn)
                .HasColumnName("Input_Date").HasColumnType("datetime");
            builder
                .Property(p => p.DateOut)
                .HasColumnName("Output_Date").HasColumnType("datetime").IsRequired(true);
            builder
                .Property(p => p.Status).HasColumnName("Status_Product").
                HasColumnType("varchar(100)").IsRequired(true);
            builder
                .Property(p => p.Name).HasColumnName("Name_Product").
                HasColumnType("varchar(50)").IsRequired(true);
            builder
                .Property(p => p.Price).HasColumnName("Price_Product").HasColumnType("float");

        }
    }
}