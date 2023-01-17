namespace BonusProject.model;

public class Student : Entity<int>
{

    public String StudentName { get; set;}

    public String StudentSchool { get; set;}

    public Student(int id) : base(id)
    {
    }

    public Student(int id, string studentName, string studentSchool) : base(id)
    {
        StudentName = studentName;
        StudentSchool = studentSchool;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}