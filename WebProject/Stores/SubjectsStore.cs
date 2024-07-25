using WebProject.Exceptions;
using WebProject.Models;

namespace WebProject.Store
{
    public class SubjectsStore
    {
        private static readonly List<Subject> _subjects;
        private static int _id;

        static SubjectsStore()
        {
            _subjects = new List<Subject>();
            _subjects.Add(new Subject()
            {
                Id = 1,
                Name = "C#/.NET",
                Description = "Fundamentals of .NET Development.",
                Price = 1500,
                Discount = 0,
                NumberOfModules = 12,
                Rating = 5
            });
            _subjects.Add(new Subject()
            {
                Id = 2,
                Name = "JavaScript",
                Description = "Fundamentals of Web Development with JavaScript.",
                Price = 1400,
                Discount = 15,
                NumberOfModules = 10,
                Rating = 4.5
            });
            _id = 3;
        }

        public List<Subject> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return [.. _subjects];
            }

            var filteredSubjects = _subjects.Where(x => x.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                (x.Description != null && x.Description.Contains(search, StringComparison.InvariantCultureIgnoreCase)));

            return filteredSubjects.ToList();
        }

        public Subject GetById(int id)
        {
            if (!TryGet(out var subject, id))
            {
                throw new DataNotFoundException($"Subject with id:{id} is not found");
            }
            return subject;
        }

        public void Add(Subject subject)
        {
            ValidateSubject(subject);
            subject.Id = _id++;

            _subjects.Add(subject);
        }

        public void Update(Subject subject)
        {
            ValidateSubject(subject);

            var index = _subjects.FindIndex(x => x.Id == subject.Id);
            
            if (index < 0)
            {
                throw new DataNotFoundException($"Subject with id:{subject.Id} is not found");
            }

            _subjects[index] = subject;
        }

        public void Delete(int id)
        {
            if (!TryGet(out var subject, id))
            {
                throw new DataNotFoundException($"Subject with id:{id} is not found");
            }

            _subjects.Remove(subject);
        }

        private static void ValidateSubject(Subject subject)
        {
            ArgumentNullException.ThrowIfNull(subject);

            if (subject.Price < 1)
            {
                throw new InvalidPriceException("Price must be greater than 0");
            }
        }

        private static bool TryGet(out Subject subject, int id)
        {
            var element = _subjects.Find(x => x.Id == id);

            if (element is null)
            {
                subject = new();
                return false;
            }
            
            subject = element;
            
            return true;
        }
    }
}
