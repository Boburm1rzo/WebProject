using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Extensions;
using University.ViewModels.Student;

namespace University.Tests.Unit.Extensions;

public class StudentMappings
{
    [Fact]
    public void ShouldThrowException_WhenToEntityCalled_WithNull()
    {
        StudentCreateView view = null!;

        Assert.Throws<ArgumentNullException>(() => view!.ToEntity());
    }

    [Fact]
    public void ShouldCorrectly_MapToEntity()
    {
        StudentCreateView view = new StudentCreateView 
        { 
            FirstName = "John", 
            LastName = "Doe", 
            Email = "john@gmail.com", 
            PhoneNumber = "+998914045014" 
        };
        var entity = view.ToEntity();

        Assert.Equal("John", entity.FirstName);
        Assert.Equal("Doe", entity.LastName);
        Assert.Equal("john@gmail.com", entity.Email);
        Assert.Equal("+998914045014", entity.PhoneNumber);
    }
}
