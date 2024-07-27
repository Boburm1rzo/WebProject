namespace University.Domain.Entities;

public class MentorCourse
{
    public int Id { get; set; }

    public int MentorId { get; set; }
    public virtual Mentor Mentor { get; set; }

    public int CourseId { get; set; }
    public virtual Course Course { get; set; }
}
