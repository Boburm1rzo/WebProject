using Bogus;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;
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
}
