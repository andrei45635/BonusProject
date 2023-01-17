namespace BonusProject.model;

public class Game: Entity<int>
{
    public Team HomeTeam { get; set;}

    public Team AwayTeam { get; set;}

    public DateTime Date { get; set;}

    public Game(int id) : base(id)
    {
    }
    
    public Game(int id, Team homeTeam, Team awayTeam, DateTime date) : base(id)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        Date = date;
    }

    public override string ToString()
    {
        return "Home Team: " + HomeTeam.TeamName + "\nAway Team: " + AwayTeam.TeamName + "\nDate: " + Date;
    }
}