using System;
using System.Collections.Generic;
using System.Linq;

namespace generics.Entity
{
class Person 
{ 
    public int Id { get; set; }
    public string Name { get; set; }
}

class Student : Person
{
    public void SubmitWork()
    {
        Console.WriteLine($"{Name} submitted work.");
    }

    public void SayName()
    {
        Console.WriteLine($"My name is {Name}, student ID: {Id}");
    }
}


class Teacher : Person
{
    public void GradeStudent(Student student, int grade)
    {
        Console.WriteLine($"Teacher {Name} graded student {student.Name} with {grade}");
    }

    public void ExpelStudent(Student student)
    {
        Console.WriteLine($"Teacher {Name} expelled student {student.Name}");
    }

    public void ShowPresentStudents(IEnumerable<Student> students)
    {
        Console.WriteLine($"Teacher {Name} is checking attendance:");
        foreach (var student in students)
        {
            Console.WriteLine($" {student.Name} is present");
        }
        class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    private IRepository<Student, int> _students = new InMemoryRepository<Student, int>();

    public void AddStudent(Student student)
    {
        _students.Add(student.Id, student);
    }

    public void RemoveStudent(int studentId)
    {
        _students.Remove(studentId);
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _students.GetAll();
    }

    public Student FindStudent(int studentId)
    {
        return _students.Get(studentId);
    }
class Faculty
{
    public int Id { get; set; }
    public string Name { get; set; }
    private IRepository<Group, int> _groups = new InMemoryRepository<Group, int>();

    public void AddGroup(Group group)
    {
        _groups.Add(group.Id, group);
    }

    public void RemoveGroup(int id)
    {
        _groups.Remove(id);
    }

    public IEnumerable<Group> GetAllGroups()
    {
        return _groups.GetAll();
    }

    public Group GetGroup(int id)
    {
        return _groups.Get(id);
    }
    }
