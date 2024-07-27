namespace WebProject.ViewModels.Course;

public class CreateCourseView
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int NumberOfModules { get; set; }
    public double Rating { get; set; }
    public decimal Discount { get; set; }
}
