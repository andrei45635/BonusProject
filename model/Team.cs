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

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}