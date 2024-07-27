using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace University.Infrastructure.Configurations;

internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasMany(x => x.Mentors)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(ConfigurationDefaults.DefaultStringLength)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(ConfigurationDefaults.MaxStringLength)
            .IsRequired(false);
        builder.Property(x => x.Price)
            .HasColumnType("money")
            .HasPrecision(13, 2)
            .IsRequired();
        builder.Property(x => x.Discount)
            .HasColumnType("money")
            .HasPrecision(13, 2)
            .IsRequired();
    }
}
