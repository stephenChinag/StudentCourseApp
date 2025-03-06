using System;

class Program
{
    static void Main()
    {
        var service = new StudentCourseService();
        
        while (true)
        {
            Console.WriteLine("\n🎓 Student Course Management System");
            Console.WriteLine("1️⃣ Add Student");
            Console.WriteLine("2️⃣ Add Course");
            Console.WriteLine("3️⃣ Enroll Student in Course");
            Console.WriteLine("4️⃣ Display Enrollments");
            Console.WriteLine("5️⃣ Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter student name: ");
                    string studentName = Console.ReadLine();
                    service.AddStudent(studentName);
                    break;

                case "2":
                    Console.Write("Enter course title: ");
                    string courseTitle = Console.ReadLine();
                    service.AddCourse(courseTitle);
                    break;

                case "3":
                    Console.Write("Enter Student ID: ");
                    int studentId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Course ID: ");
                    int courseId = int.Parse(Console.ReadLine());

                    service.EnrollStudent(studentId, courseId);
                    break;

                case "4":
                    service.DisplayEnrollments();
                    break;

                case "5":
                    Console.WriteLine("🚀 Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("❌ Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
