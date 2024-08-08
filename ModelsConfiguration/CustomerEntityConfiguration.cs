
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_C__Data_Access_with_Dapper_and_SQL.Models;

namespace Simple_C__Data_Access_with_Dapper_and_SQL.ModelsConfiguration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.DateOfBirth)
                    .IsRequired();

            builder.Property(e => e.FirstName)
                .IsUnicode(false)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.LastName)
               .IsUnicode(false)
               .HasMaxLength(256)
               .IsRequired();

            builder.Property(e => e.Email)
               .IsUnicode(false)
               .HasMaxLength(256)
               .IsRequired();


        }
    }
}
