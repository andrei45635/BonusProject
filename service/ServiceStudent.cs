using BonusProject.model;
using BonusProject.repository;

namespace BonusProject.service;

public class ServiceStudent
{
    private IRepository<int, Student> Repository;

    public ServiceStudent(IRepository<int, Student> repository)
    {
        Repository = repository;
    }

    public List<Student> GetAll()
    {
        return Repository.FindAll().ToList();
    }

    public Student Save(Student st)
    {
        return Repository.Save(st);
    }
}