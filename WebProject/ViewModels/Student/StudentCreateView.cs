namespace University.ViewModels.Student
{
    public class StudentCreateView
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}