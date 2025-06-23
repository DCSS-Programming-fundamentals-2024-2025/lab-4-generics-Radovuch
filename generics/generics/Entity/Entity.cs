using System;
using System.Collections.Generic;
using System.Reflection;

namespace generics.Entity
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Student : Person
    {
        public void SubmitWork() => Console.WriteLine($"{Name} submitted work.");
        public void SayName() => Console.WriteLine($"My name is {Name}, student ID: {Id}");
    }

    class Teacher : Person
    {
        public void GradeStudent(Student student, int grade) =>
            Console.WriteLine($"Teacher {Name} graded student {student.Name} with {grade}");

        public void ExpelStudent(Student student) =>
            Console.WriteLine($"Teacher {Name} expelled student {student.Name}");

        public void ShowPresentStudents(IEnumerable<Student> students)
        {
            Console.WriteLine($"Teacher {Name} is checking attendance:");
            foreach (var student in students)
            {
                Console.WriteLine($" {student.Name} is present");
            }
        }
    }
    public class InMemoryRepository<TEntity, TKey> :
        IRepository<TEntity, TKey>,
        IReadOnlyRepository<TEntity, TKey>,
        IWriteRepository<TEntity, TKey>
        where TEntity : class, new()
        where TKey : struct
    {
        private Dictionary<TKey, TEntity> _storage = new Dictionary<TKey, TEntity>();

        public void Add(TKey id, TEntity entity) => _storage[id] = entity;
        public TEntity Get(TKey id) => _storage.ContainsKey(id) ? _storage[id] : null;
        public IEnumerable<TEntity> GetAll() => _storage.Values;
        public void Remove(TKey id) => _storage.Remove(id);
        void IWriteRepository<TEntity, TKey>.Add(TEntity entity)
        {
            PropertyInfo prop = typeof(TEntity).GetProperty("Id");
            if (prop != null)
            {
                TKey id = (TKey)prop.GetValue(entity);
                _storage[id] = entity;
            }
        }
        void IWriteRepository<TEntity, TKey>.Remove(TKey id) => _storage.Remove(id);
    }
    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private IRepository<Student, int> _students = new InMemoryRepository<Student, int>();

        public void AddStudent(Student s) => _students.Add(s.Id, s);
        public void RemoveStudent(int studentId) => _students.Remove(studentId);
        public IEnumerable<Student> GetAllStudents() => _students.GetAll();
        public Student FindStudent(int studentId) => _students.Get(studentId);
    }
    class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private IRepository<Group, int> _groups = new InMemoryRepository<Group, int>();

        public void AddGroup(Group g) => _groups.Add(g.Id, g);
        public void RemoveGroup(int id) => _groups.Remove(id);
        public IEnumerable<Group> GetAllGroups() => _groups.GetAll();
        public Group GetGroup(int id) => _groups.Get(id);
        public void AddStudentToGroup(int groupId, Student s)
        {
            var group = _groups.Get(groupId);
            group?.AddStudent(s);
        }
        public void RemoveStudentFromGroup(int groupId, int studentId)
        {
            var group = _groups.Get(groupId);
            group?.RemoveStudent(studentId);
        }
        public IEnumerable<Student> GetAllStudentsInGroup(int groupId)
        {
            var group = _groups.Get(groupId);
            return group?.GetAllStudents();
        }
        public Student FindStudentInGroup(int groupId, int studentId)
        {
            var group = _groups.Get(groupId);
            return group?.FindStudent(studentId);
        }
    }
}
