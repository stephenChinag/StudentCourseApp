using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class StudentCourseService
{
    private readonly AppDbContext _context;

    public StudentCourseService()
    {
        _context = new AppDbContext();
        _context.Database.EnsureCreated(); // Ensure DB is created
    }

    public void AddStudent(string name)
    {
        _context.Students.Add(new Student { Name = name });
        _context.SaveChanges();
        Console.WriteLine($"✅ Student '{name}' added successfully!");
    }

    public void AddCourse(string title)
    {
        _context.Courses.Add(new Course { Title = title });
        _context.SaveChanges();
        Console.WriteLine($"✅ Course '{title}' added successfully!");
    }

    public void EnrollStudent(int studentId, int courseId)
    {
        var student = _context.Students.Find(studentId);
        var course = _context.Courses.Find(courseId);

        if (student != null && course != null)
        {
            _context.Enrollments.Add(new Enrollment { StudentId = studentId, CourseId = courseId });
            _context.SaveChanges();
            Console.WriteLine($"✅ {student.Name} has been enrolled in {course.Title}!");
        }
        else
        {
            Console.WriteLine("❌ Invalid Student or Course ID.");
        }
    }

    public void DisplayEnrollments()
    {
        var enrollments = _context.Enrollments.Include(e => e.Student).Include(e => e.Course).ToList();

        Console.WriteLine("\n📚 Student Course Enrollments:");
        foreach (var enrollment in enrollments)
        {
            Console.WriteLine($"- {enrollment.Student.Name} is enrolled in {enrollment.Course.Title}");
        }
    }
}
