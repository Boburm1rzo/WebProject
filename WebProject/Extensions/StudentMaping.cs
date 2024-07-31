using University.Domain.Entities;
using WebProject.ViewModels.Student;

namespace WebProject.Extensions
{
    public static class StudentMaping
    {
        public static Student ToEntity(this StudentCreateView student)
        {
            return new Student
            {
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
            };
        }
        public static Student ToEntity(this StudentUpdateView view)
        {
            var entity = ToEntity(view as StudentCreateView);
            entity.Id = view.Id;

            return entity;
        }
        public static StudentView ToView(this Student student)
        {
            return new StudentView
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
            };
        }
        public static StudentUpdateView ToUpdateView(this Student student)
        {
            return new StudentUpdateView
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
            };
        }
    }
}
