using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;
using University.Domain.Enums;

namespace University.Infrastructure.Configurations;

internal class MentorConfiguration : IEntityTypeConfiguration<Mentor>
{
    public void Configure(EntityTypeBuilder<Mentor> builder)
    {
        builder.HasMany(x => x.Courses)
            .WithOne(c => c.Mentor)
            .HasForeignKey(c => c.MentorId)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasMaxLength(ConfigurationDefaults.DefaultStringLength)
            .IsRequired();
        builder.Property(x => x.LastName)
            .HasMaxLength(ConfigurationDefaults.DefaultStringLength)
            .IsRequired();
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(ConfigurationDefaults.PhoneNumberLength)
            .IsRequired();
        builder.Property(x => x.Degree)
            .HasDefaultValue(Degree.Bachelor)
            .IsRequired();
    }
}
