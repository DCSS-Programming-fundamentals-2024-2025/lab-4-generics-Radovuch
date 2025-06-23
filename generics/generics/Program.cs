using System;
using generics.Entity;

class Program
{
    static void Main(string[] args)
    {
        Faculty fpm = new Faculty { Id = 1, Name = "Факультет прикладної математики" };
        Group kp41 = new Group { Id = 41, Name = "КП-41" };
        Group kp42 = new Group { Id = 42, Name = "КП-42" };
        Group kp43 = new Group { Id = 43, Name = "КП-43" };
        fpm.AddGroup(kp41);
        fpm.AddGroup(kp42);
        fpm.AddGroup(kp43);
        Student student1 = new Student { Id = 1, Name = "LEGEZA" };
        Student student2 = new Student { Id = 2, Name = "Denis" };
        Student student3 = new Student { Id = 3, Name = "Student3" };
        Student student4 = new Student { Id = 4, Name = "Student4" };
        Student student5 = new Student { Id = 5, Name = "Student5" };
        fpm.AddStudentToGroup(41, student1);
        fpm.AddStudentToGroup(41, student2);
        fpm.AddStudentToGroup(42, student3);
        fpm.AddStudentToGroup(43, student4);
        fpm.AddStudentToGroup(43, student5);
        Console.WriteLine("Студенти групи КП-41:");
        foreach (Student student in kp41.GetAllStudents())
        {
            Console.WriteLine("Студент: " + student.Name + ", ID: " + student.Id);
        };
        IReadOnlyRepository<Student, int> studRepo = new InMemoryRepository<Student, int>();
        IReadOnlyRepository<Person, int> persRepo = studRepo;  
        IWriteRepository<Student, int> persWrite = new InMemoryRepository<Student, int>();
        IWriteRepository<Student, int> studWrite = persWrite;
        
    }
}
