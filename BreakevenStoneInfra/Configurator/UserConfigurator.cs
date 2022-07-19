using BreakevenStoneDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakevenStoneInfra.Configurator
{
    public class UserConfigurator: IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .ToTable("User");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("Id_User");
            builder
                .Property(p => p.UserFirstName).HasColumnName("First_Name")
                .HasColumnType("varchar(20)").IsRequired();
            builder
                .Property(p => p.UserLastName).HasColumnName("Last_Name")
                .HasColumnType("varchar(20)").IsRequired();
            builder
                .Property(p => p.Password).HasColumnName("Password")
                .HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(p => p.CPF).HasColumnName("CPF").
                HasColumnType("varchar(11)").IsRequired();
            builder
                .Property(p => p.Birthday).HasColumnName("Birthday").IsRequired();
            builder
                .Property(p => p.Address).HasColumnName("Address").HasColumnType("varchar(200)");
            builder
                .Property(p => p.Email).HasColumnName("Email").IsRequired();
        }
    }
}