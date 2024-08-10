using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;
using University.Exceptions;
using University.Infrastructure;

namespace University.Store
{
    public class StudentStore
    {
        public List<Student> Get(string? search)
        {
            using var context = new UniversityDbContext();

            var query = context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.LastName.Contains(search) ||
                                         x.FirstName.Contains(search));
            }

            var students = query
                .AsNoTracking()
                .ToList();

            return students;
        }

        public Student GetById(int id)
        {
            using var context = new UniversityDbContext();

            var student = context.Students
                .AsNoTracking()
                .Include(x => x.Enrollments)
                .ThenInclude(e => e.Group)
                .ThenInclude(g => g.MentorSubject)
                .ThenInclude(ms => ms.Mentor)
                .Include(x => x.Enrollments)
                .ThenInclude(e => e.Group)
                .ThenInclude(g => g.MentorSubject)
                .ThenInclude(ms => ms.Course)
                .FirstOrDefault(x => x.Id == id);

            if (student is null)
            {
                throw new DataNotFoundException($"Student with id:{id} is not found");
            }

            return student;
        }

        public void Add(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);

            using var context = new UniversityDbContext();

            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);

            using var context = new UniversityDbContext();

            context.Students.Update(student);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new UniversityDbContext();

            var student = context.Students.FirstOrDefault(x => x.Id == id);

            if (student is null)
            {
                throw new DataNotFoundException($"Student with id:{id} is not found");
            }

            context.Students.Remove(student);
            context.SaveChanges();
        }
    }
}
