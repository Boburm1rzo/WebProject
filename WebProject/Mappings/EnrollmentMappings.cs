using University.Domain.Entities;
using University.ViewModels.Enrollment;
using University.ViewModels.Group;

namespace University.Mappings;

public static class EnrollmentMappings
{
    public static GroupViewModel ToGroup(this Enrollment enrollment)
    {
        ArgumentNullException.ThrowIfNull(enrollment);

        return new GroupViewModel
        {
            Id = enrollment.GroupId,
            Mentor = enrollment.Group.MentorSubject.Mentor.FirstName + " " + enrollment.Group.MentorSubject.Mentor.LastName,
            Name = enrollment.Group.Name,
            Subject = enrollment.Group.MentorSubject.Course.Name,
            Mode = enrollment.Group.Mode,
            Type = enrollment.Group.Type,
        };
    }

    public static EnrollmentViewModel ToView(this Enrollment enrollment)
    {
        return new EnrollmentViewModel
        {
            Id = enrollment.Id,
            Group = enrollment.Group.Name,
            Student = enrollment.Student.FirstName + " " + enrollment.Student.LastName
        };
    }
}
