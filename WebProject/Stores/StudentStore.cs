using WebProject.Exceptions;
using WebProject.Models;

namespace WebProject.Store
{
    public class StudentStore
    {
        private static readonly List<Student> _students = [];
        public List<Student> Get()=>_students.ToList();
        public Student GetById(int id)
        {
            if(!FindStudent(out var student,id))
            {
                throw new DataNotFoundException($"Student with id:{id} is not found");
            }
            return student;
        }
        public void Add(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);
            _students.Add(student);
        }
        public void Delete(int id)
        {
            if (FindStudent(out var student ,id))
            {
                throw new DataNotFoundException($"Student with id:{id} is not found");
            }
            _students.Remove(student);
        }
        public void Update(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);
            var index = _students.FindIndex(x => x.Id == student.Id);
            if (index<0)
            {
                throw new DataNotFoundException($"Student with id:{student.Id} is not found");
            }
            _students[index] = student;
        }
        private static bool FindStudent(out Student student, int id)
        {
            var element = _students.Find(x => x.Id == id);
            if (element is null)
            {
                student = new();
                return false;
            }
            student = element;
            return true;
        }
    }
}
