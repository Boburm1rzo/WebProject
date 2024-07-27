namespace University.Domain.Entities;

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public virtual Student Student { get; set; }

    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
}
