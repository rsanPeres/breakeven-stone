using BreakevenStoneDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakevenStoneInfra.Configurator
{
    public class EmployeeConfigurator : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .ToTable("Employee");
            builder
                .Property(p => p.EmployeeId).HasColumnName("Id_Employee");
            builder
                .Property(p => p.Fuction).HasColumnName("Function_Employee")
                .HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(p => p.Salary).HasColumnName("Salary").HasColumnType("float");
        }
    }
}