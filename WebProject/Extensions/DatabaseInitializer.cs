using Bogus;
using System.Security.Cryptography.Xml;
using University.Domain.Entities;
using University.Domain.Enums;
using University.Infrastructure;

namespace University.Extensions;

public class DatabaseInitializer
{
    private static readonly Faker _faker = new();

    public static void SeedDatabase()
    {
        using var context = new UniversityDbContext();

        try
        {
            AddStudents(context);
            AddCourses(context);
            AddMentors(context);
            AddMentorCourses(context);
            AddGroups(context);
            AddEnrollments(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static void AddStudents(UniversityDbContext context)
    {
        if (context.Students.Any())
        {
            return;
        }

        List<Student> students = [];

        for (int i = 0; i < 100; i++)
        {
            var student = new Student
            {
                FirstName = _faker.Name.FirstName(),
                LastName = _faker.Name.LastName(),
                PhoneNumber = _faker.Phone.PhoneNumber("+998#########"),
                Email = _faker.Person.Email
            };

            students.Add(student);
        }

        context.Students.AddRange(students);
        context.SaveChanges();
    }

    private static void AddCourses(UniversityDbContext context)
    {
        if (context.Courses.Any())
        {
            return;
        }

        List<Course> courses = [];

        for (int i = 0; i < 20; i++)
        {
            var courseName = _faker.Name.JobTitle();
            int attempts = 0;

            while (courses.Any(x => x.Name == courseName) && attempts < 20)
            {
                courseName = _faker.Name.JobTitle();
                attempts++;
            }

            if (attempts == 20)
            {
                continue;
            }

            var course = new Course
            {
                Name = _faker.Name.JobTitle(),
                Description = _faker.Name.JobDescriptor(),
                Price = _faker.Random.Decimal(1_200_000, 5_000_000),
                Discount = _faker.Random.Decimal(0, 100),
                Rating = _faker.Random.Double(1, 5),
                NumberOfModules = _faker.Random.Int(6, 10)
            };

            courses.Add(course);
        }

        context.Courses.AddRange(courses);
        context.SaveChanges();
    }

    private static void AddMentors(UniversityDbContext context)
    {
        if (context.Mentors.Any())
        {
            return;
        }

        List<Mentor> mentors = [];

        for (int i = 0; i < 50; i++)
        {
            var mentor = new Mentor
            {
                FirstName = _faker.Name.FirstName(),
                LastName = _faker.Name.LastName(),
                Degree = _faker.Random.Enum<Degree>(),
                PhoneNumber = _faker.Phone.PhoneNumber("+998#########")
            };

            mentors.Add(mentor);
        }

        context.Mentors.AddRange(mentors);
        context.SaveChanges();
    }

    private static void AddMentorCourses(UniversityDbContext context)
    {
        if (context.MentorCourses.Any())
        {
            return;
        }

        var courseIds = context.Courses.Select(x => x.Id).ToList();
        var mentorIds = context.Mentors.Select(x => x.Id).ToList();

        foreach (var mentor in mentorIds)
        {
            var numberOfCourses = _faker.Random.Int(1, 4);
            HashSet<int> mentorCourses = [];

            for (int i = 0; i < numberOfCourses; i++)
            {
                var randomId = _faker.PickRandom(courseIds);
                mentorCourses.Add(randomId);
            }

            foreach (var mentorCourseId in mentorCourses)
            {
                var mentorCourse = new MentorCourse
                {
                    MentorId = mentor,
                    CourseId = mentorCourseId,
                };

                context.MentorCourses.Add(mentorCourse);
            }
        }

        context.SaveChanges();
    }

    private static void AddGroups(UniversityDbContext context)
    {
        if (context.Groups.Any())
        {
            return;
        }

        var mentors = context.MentorCourses.Select(x => x.Id).ToList();

        for (int i = 0; i < 100; i++)
        {
            var mentorId = _faker.PickRandom(mentors);
            var group = new Group
            {
                Name = _faker.Lorem.Word(),
                Mode = _faker.Random.Enum<StudyMode>(),
                Type = _faker.Random.Enum<CourseType>(),
                MentorSubjectId = mentorId,
            };

            context.Groups.Add(group);
        }

        context.SaveChanges();
    }

    private static void AddEnrollments(UniversityDbContext context)
    {
        if (context.Enrollments.Any())
        {
            return;
        }

        var groups = context.Groups.Select(x => x.Id).ToList();
        var students = context.Students.Select(x => x.Id).ToList();

        foreach(var student in students)
        {
            var numberOfGroups = _faker.Random.Int(1, 5);
            for(int i = 0; i < numberOfGroups; i++)
            {
                int attempts = 0;
                var randomGroupId = _faker.PickRandom(groups);
                HashSet<int> studentGroups = new HashSet<int>();

                while (studentGroups.Contains(randomGroupId) && attempts++ < 100)
                {
                    randomGroupId = _faker.PickRandom(groups);
                }

                if (attempts < 100)
                {
                    studentGroups.Add(randomGroupId);
                }

                foreach(var studentGroup in studentGroups) 
                {
                    context.Enrollments.Add(new Enrollment
                    {
                        GroupId = studentGroup,
                        StudentId = student
                    });
                }
            }
        }

        context.SaveChanges();
    }
}
