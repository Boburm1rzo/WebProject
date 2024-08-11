using Bogus;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;
using University.Exceptions;
using University.Infrastructure;

namespace University.Stores;

public class EnrollmentsStore
{
    public List<Enrollment> Get(string? search = null, int? groupId = null)
    {
        using var context = new UniversityDbContext();

        var query = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Group)
            .AsQueryable()
            .AsSplitQuery();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => 
                x.Student.FirstName.Contains(search) || 
                x.Student.LastName.Contains(search) || 
                x.Group.Name.Contains(search));
        }

        if (groupId.HasValue)
        {
            query = query.Where(x => x.GroupId == groupId);
        }

        return query.ToList();
    }
    public Enrollment GetById(int id)
    {
        using var context=new UniversityDbContext();

        var enrollment = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Group)
            .FirstOrDefault(x => x.Id == id);
        if(enrollment is null)
        {
            throw new DataNotFoundException($"Enrollment with id:{id} is not found");
        }

        return enrollment;
    }
    public void Add(Enrollment enrollment)
    {
        ArgumentNullException.ThrowIfNull(enrollment);

        using var context=new UniversityDbContext();    

        context.Enrollments.Add(enrollment);
        context.SaveChanges();
    }
    public void Update(Enrollment enrollment)
    {
        ArgumentNullException.ThrowIfNull(enrollment);

        using var context=new UniversityDbContext();

        context.Enrollments.Update(enrollment);
        context.SaveChanges();
    }
    public void Delete(int id)
    {
        using var context=new UniversityDbContext();

        var enrollment= context.Enrollments.FirstOrDefault(x=> x.Id == id);

        if (enrollment is null)
        {
            throw new DataNotFoundException($"Enrollment with id:{id} is not found");
        }

        context.Enrollments.Remove(enrollment);
        context.SaveChanges();
    }
}
