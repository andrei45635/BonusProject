using BonusProject.model;
using BonusProject.repository;
using BonusProject.service;
using BonusProject.validator;

public class Program
{
    public static void Main(string[] args)
    {
        IRepository<int, ActivePlayer> activePlayerRepo = new ActivePlayerFileRepo(new ActivePlayerValidator(), "data/activePlayer.txt");
        IRepository<int, Game> gameRepo = new GameFileRepo(new GameValidator(), "data/game.txt");
        IRepository<int, Player> playerRepo = new PlayerFileRepo(new PlayerValidator(), "data/player.txt");
        IRepository<int, Student> studentRepo = new StudentFileRepo(new StudentValidator(), "data/student.txt");
        IRepository<int, Team> teamRepo = new TeamFileRepo(new TeamValidator(), "data/team.txt");

        ServiceActivePlayer serviceActivePlayer = new ServiceActivePlayer(activePlayerRepo);
        ServiceGame serviceGame = new ServiceGame(gameRepo);
        ServicePlayer servicePlayer = new ServicePlayer(playerRepo);
        ServiceStudent serviceStudent = new ServiceStudent(studentRepo);
        ServiceTeam serviceTeam = new ServiceTeam(teamRepo);
        
        
    }
    
}