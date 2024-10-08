﻿using University.ViewModels.Group;

namespace University.ViewModels.Student;

public class StudentView
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }

    public List<GroupViewModel> Groups { get; set; }
}
