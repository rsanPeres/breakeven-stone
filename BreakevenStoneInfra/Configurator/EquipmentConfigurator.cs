using BreakevenStoneDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakevenStoneInfra.Configurator
{
    public class EquipmentConfigurator: IEntityTypeConfiguration<Equipment>
    {

        public void Configure(EntityTypeBuilder<Equipment> builder)
        {

            builder
                .ToTable("Equipment");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("Id_Equipment");
            builder
                .Property(p => p.Name).HasColumnName("Name_Equipment")
                .HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(p => p.DateIn).HasColumnName("Input_date")
                .HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(p => p.Description).HasColumnName("Description_Equipment")
                .HasColumnType("varchar(100)");
            builder
                .Property(p => p.Price).HasColumnName("Price").HasColumnType("float");
        }
    }
}