using DomainLayer.Entities;

namespace DomainLayer.Contracts
{
    public interface IDatabase
    {
        Student GetStudent(int id);
        Student GetAllStudents();

        Class GetClass(int id);
        Class GetAllClasses();

        Class GetCourse();
    }
}