using University.Domain.Enums;

namespace University.Domain.Entities;

public class Mentor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public Degree Degree { get; set; }

    public virtual IEnumerable<MentorCourse> Courses { get; set; }
}
