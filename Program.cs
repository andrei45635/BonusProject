using BonusProject.model;
using BonusProject.repository;
using BonusProject.service;
using BonusProject.user_interface;
using BonusProject.validator;

public class Program
{
    public static void Main(string[] args)
    {
        IRepository<int, ActivePlayer> activePlayerRepo = new ActivePlayerFileRepo(new ActivePlayerValidator(), "C:\\Users\\Andrei\\Desktop\\Facultate\\Semestrul 3\\MAP\\BonusProject\\data\\activePlayer.txt");
        IRepository<int, Game> gameRepo = new GameFileRepo(new GameValidator(), "C:\\Users\\Andrei\\Desktop\\Facultate\\Semestrul 3\\MAP\\BonusProject\\data\\game.txt");
        IRepository<int, Player> playerRepo = new PlayerFileRepo(new PlayerValidator(), "C:\\Users\\Andrei\\Desktop\\Facultate\\Semestrul 3\\MAP\\BonusProject\\data\\player.txt");
        IRepository<int, Team> teamRepo = new TeamFileRepo(new TeamValidator(), "C:\\Users\\Andrei\\Desktop\\Facultate\\Semestrul 3\\MAP\\BonusProject\\data\\team.txt");
        
        UI userInterface = new UI(new Service(activePlayerRepo, gameRepo, playerRepo, teamRepo));

        userInterface.RunProgram();
    }
    
}