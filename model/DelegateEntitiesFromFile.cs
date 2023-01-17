namespace BonusProject.model;

public class DelegateEntitiesFromFile
{
    private static char Separator = ';';

    public static ActivePlayer ActivePlayerDelegate(string line)
    {
        string[] splitActivePlayer = line.Split(Separator);
        ActivePlayer activePlayer = new ActivePlayer(int.Parse(splitActivePlayer[0]), int.Parse(splitActivePlayer[1]), int.Parse(splitActivePlayer[2]), int.Parse(splitActivePlayer[3]), (PlayerType)Enum.Parse(typeof(PlayerType), splitActivePlayer[4]));
        return activePlayer;
    }

    public static Game GameDelegate(string line)
    {
        string[] splitGame = line.Split(Separator);
        Team HomeTeam = new Team(int.Parse(splitGame[1]));
        Team AwayTeam = new Team(int.Parse(splitGame[2]));
        Game game = new Game(int.Parse(splitGame[0]), HomeTeam, AwayTeam, DateTime.Parse(splitGame[3]));
        return game;
    }

    public static Student StudentDelegate(string line)
    {
        string[] splitStudent = line.Split(Separator);
        Student student = new Student(int.Parse(splitStudent[0]), splitStudent[1], splitStudent[2]);
        return student;
    }

    public static Team TeamDelegate(string line)
    {
        string[] splitTeam = line.Split(Separator);
        Team team = new Team(int.Parse(splitTeam[0]), splitTeam[1]);
        return team;
    }

    public static Player PlayerDelegate(string line)
    {
        string[] splitPlayer = line.Split(Separator);
        Player player = new Player(int.Parse(splitPlayer[0]), splitPlayer[1], splitPlayer[2], splitPlayer[3]);
        return player;
    }
}