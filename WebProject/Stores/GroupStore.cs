using University.Domain.Entities;
using University.Infrastructure;
using University.Exceptions;

namespace University.Stores
{
    public class GroupStore
    {
        public List<Group> Get()
        {
            using var context = new UniversityDbContext();

            var query = context.Groups.AsQueryable();

            return query.ToList();
        }
        public Group GetById(int id)
        {
            using var context = new UniversityDbContext();

            var group = context.Groups.FirstOrDefault(x => x.Id == id);

            if (group is null)
            {
                throw new DataNotFoundException($"Group with id:{id} is not found");
            }

            return group;
        }
        public void Add(Group group)
        {
            ArgumentNullException.ThrowIfNull(group);

            using var context = new UniversityDbContext();

            context.Groups.Add(group);
            context.SaveChanges();
        }
        public void Update(Group group)
        {
            ArgumentNullException.ThrowIfNull(group);

            using var context = new UniversityDbContext();

            context.Groups.Update(group);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            using var context = new UniversityDbContext();

            var group = context.Groups.FirstOrDefault(x => x.Id == id);

            if (group is null)
            {
                throw new DataNotFoundException($"Group with id:{id} is not found");
            }

            context.Groups.Remove(group);
            context.SaveChanges();
        }



    }
}
