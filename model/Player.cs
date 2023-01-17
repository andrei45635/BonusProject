namespace BonusProject.model;

public class Player : Student
{
    public String PlayerTeam { get; set;}

    public Player(int id) : base(id)
    {
    }

    public Player(int id, string studentName, string studentSchool, string playerTeam) : base(id, studentName, studentSchool)
    {
        this.PlayerTeam = playerTeam;
    }

    public override string ToString()
    {
        return PlayerTeam;
    }
}