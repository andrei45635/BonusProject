using BonusProject.model;
using BonusProject.validator;

namespace BonusProject.repository;

public class StudentFileRepo: FileRepository<int, Student>
{
    public StudentFileRepo(IValidator<Student> validator, string fileName) : base(validator, fileName, DelegateEntitiesFromFile.StudentDelegate)
    {
    }
}