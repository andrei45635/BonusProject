namespace BonusProject.model;

public class Team:Entity<int>
{

    public String TeamName { get; set;}
    
    public Team(int id) : base(id)
    {
    }

    public Team(int id, string teamName) : base(id)
    {
        TeamName = teamName;
    }
    
    public override string ToString()
    {
        return ID + "; " + TeamName;
    }
}