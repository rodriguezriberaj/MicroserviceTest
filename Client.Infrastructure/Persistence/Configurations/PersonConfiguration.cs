using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.UseTptMappingStrategy();
            builder.ToTable("Persons");

            builder.Property(p => p.Identification)
            .HasConversion(
                id => id.Value, 
                value => new Identification(value) 
            )
            .HasColumnName("Identification") 
            .IsRequired();

            builder.HasKey(p => p.Identification);
           
            builder.OwnsOne(p => p.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("Name")
                    .IsRequired();
            });

            builder.OwnsOne(p => p.Gender, gender =>
            {
                gender.Property(g => g.Value)
                    .HasColumnName("Gender")
                    .IsRequired();
            });

            builder.OwnsOne(p => p.Age, age =>
            {
                age.Property(a => a.Value)
                    .HasColumnName("Age")
                    .IsRequired();
            });

            builder.OwnsOne(p => p.Address, address =>
            {
                address.Property(a => a.Value)
                    .HasColumnName("Address")
                    .IsRequired();
            });

            builder.OwnsOne(p => p.PhoneNumber, phone =>
            {
                phone.Property(pn => pn.Value)
                    .HasColumnName("PhoneNumber")
                    .IsRequired();
            });
        }
    }
}
