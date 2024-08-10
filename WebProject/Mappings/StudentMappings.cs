using University.Domain.Entities;
using University.ViewModels.Student;

namespace University.Mappings;

public static class StudentMappings
{
    public static Student ToEntity(this StudentCreateView student)
    {
        ArgumentNullException.ThrowIfNull(student);

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
        var entity = (view as StudentCreateView).ToEntity();
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
            Groups = student.Enrollments?.Select(x => x.ToGroup())?.ToList() ?? []
        };
    }

    public static StudentUpdateView ToUpdateView(this Student student)
    {
        return new StudentUpdateView
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber,
        };
    }
}
