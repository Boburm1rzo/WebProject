using University.Domain.Enums;

namespace University.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public StudyMode Mode { get; set; }
    public CourseType Type { get; set; }

    public int MentorSubjectId { get; set; }
    public virtual MentorCourse MentorSubject { get; set; }

    public virtual IEnumerable<Enrollment> Enrollments { get; set; }
}