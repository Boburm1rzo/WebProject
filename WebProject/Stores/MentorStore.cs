using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;
using University.Exceptions;
using University.Infrastructure;

namespace University.Stores
{
    public class MentorStore
    {
        public List<Mentor> Get()
        {
            using var context = new UniversityDbContext();

            var query = context.Mentors.AsQueryable();

            return query.AsNoTracking().ToList();
        }
        public Mentor GetById(int id)
        {
            using var context = new UniversityDbContext();
            var mentor = context.Mentors.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (mentor is null)
            {
                throw new DataNotFoundException($"Mentor with id:{id} is not found");
            }

            return mentor;
        }
        public void Add(Mentor mentor)
        {
            ArgumentNullException.ThrowIfNull(mentor);

            using var context = new UniversityDbContext();

            context.Mentors.Add(mentor);
            context.SaveChanges();
        }
        public void Update(Mentor mentor)
        {
            ArgumentNullException.ThrowIfNull(mentor);

            using var context = new UniversityDbContext();

            context.Mentors.Update(mentor);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            using var context = new UniversityDbContext();
            var mentor = context.Mentors.FirstOrDefault(x => x.Id == id);

            if (mentor is null)
            {
                throw new Exception($"Mentor with id:{id} is not found");
            }

            context.Mentors.Remove(mentor);
            context.SaveChanges();
        }
    }
}
