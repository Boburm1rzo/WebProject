namespace University.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int NumberOfModules { get; set; }
    public double Rating { get; set; }
    public decimal Discount { get; set; }

    public virtual IEnumerable<MentorCourse> Mentors { get; set; }
}
