using Microsoft.EntityFrameworkCore;
using System.Reflection;
using University.Domain.Entities;
using University.Infrastructure.Configurations;

namespace University.Infrastructure;

public class UniversityDbContext : DbContext
{
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Mentor> Mentors { get; set; }
    public virtual DbSet<MentorCourse> MentorCourses { get; set; }
    public virtual DbSet<Enrollment> Enrollments { get; set; }
    public virtual DbSet<Group> Groups { get; set; }

    public UniversityDbContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationDefaults.ConectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
