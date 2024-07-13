using WebProject.Models;
namespace WebProject.Views.Stores
{
    public class StudentStore
    {
        private static List<Student> _students = [];
        public void Add(Student student)=>_students.Add(student);
        public void Update(Student student)
        {
            var index = _students.FindIndex(x => x.Id == student.Id);
            if (index >= 0)
            {
                _students[index] = student;
            }
        }
        public void Delete(int id)
        {
            var element = _students.Find(x => x.Id == id);
            if (element != null)
            {
                _students.Remove(element);
            }
        }
        public List<Student> GetAllStudents()=>_students;
        public Student? GetById(int Id)=>_students.Find(x=>x.Id == Id);
    }
}
