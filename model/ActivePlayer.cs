namespace BonusProject.model;

public enum PlayerType
{
    RESERVE,
    ACTIVE
}

public class ActivePlayer: Entity<int>
{

    public int PlayerID { get; set;}
    
    public int GameID { get; set;}
    
    public int Score { get; set;}

    public PlayerType PlayerType { get; set;}
    
    public ActivePlayer(int id) : base(id)
    {
    }

    public ActivePlayer(int id, int playerId, int gameId, int score, PlayerType playerType) : base(id)
    {
        PlayerID = playerId;
        GameID = gameId;
        Score = score;
        PlayerType = playerType;
    }

    public override string ToString()
    {
        return this.ID + ";" + this.PlayerID + ";" + this.GameID + ";" + this.Score + ";" + this.PlayerType;
    }
}