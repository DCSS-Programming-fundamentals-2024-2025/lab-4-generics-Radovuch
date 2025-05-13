using generics.Entity;
using generics.Interfaces;
class Program
{
    static void Main(string[] args)
    {
        // Test your lab here
        Faculty fpm = new Faculty { Id = 1, Name = "Факультет прикладної математики" };
        
        // Create groups
        Group kp41 = new Group { Id = 41, Name = "КП-41" };
        Group kp42 = new Group { Id = 42, Name = "КП-42" };
        Group kp43 = new Group { Id = 43, Name = "КП-43" };
        
        fpm.AddGroup(kp41);
        fpm.AddGroup(kp42);
        fpm.AddGroup(kp43);
        
        Student student1 = new Student { Id = 1, Name = "LEGEZA" };
        Student student2 = new Student { Id = 2, Name = "1" };
        Student student3 = new Student { Id = 3, Name = "2" };
        Student student4 = new Student { Id = 4, Name = "B3" };
        Student student5 = new Student { Id = 5, Name = "5D" };
        
        fpm.AddStudentToGroup(41, student1);
        fpm.AddStudentToGroup(41, student2);
        fpm.AddStudentToGroup(42, student3);
        fpm.AddStudentToGroup(43, student4);
        fpm.AddStudentToGroup(43, student5);
       
        KP41.AddStudent(LEGEZA);
        KP41.AddStudent(Student1);
        KP41.AddStudent(Student2);
        KP42.AddStudent(Student3);
        KP43.AddStudent(Student4);
        KP43.AddStudent(Student5);
        
        KP41.GetAllStudents();

       
        IReadOnlyRepository<Student,int> studRepo = new InMemoryRepository<Student,int>();
        IReadOnlyRepository<Person,int>  persRepo = studRepo;  

        IWriteRepository<Student,int> persWrite = new InMemoryRepository<Student,int>();
        IWriteRepository<Student,int> studWrite = persWrite;  
    }
}
