using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace University.Infrastructure.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(x => x.Enrollments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(ConfigurationDefaults.DefaultStringLength)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(ConfigurationDefaults.DefaultStringLength)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(ConfigurationDefaults.DefaultStringLength)
                .IsRequired();
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(ConfigurationDefaults.PhoneNumberLength)
                .IsRequired();
        }
    }
}
