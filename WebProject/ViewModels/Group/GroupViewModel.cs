using University.Domain.Enums;

namespace University.ViewModels.Group;

public class GroupViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mentor { get; set; }
    public string Subject { get; set; }
    public CourseType Type { get; set; }
    public StudyMode Mode { get; set; }
}
