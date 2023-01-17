using BonusProject.model;

namespace BonusProject.validator;

public class StudentValidator: IValidator<Student>
{
    public void Validate(Student student)
    {
        if (student.StudentName == "")
        {
            throw new ValidatorException("Invalid student name!\n");
        }

        if (student.StudentSchool == "")
        {
            throw new ValidatorException("Invalid school name!\n");
        }
    }
}