﻿using BonusProject.model;
using BonusProject.repository;

namespace BonusProject.service;

public class Service
{
    private IRepository<int, ActivePlayer> _activePlayerRepo;
    
    private IRepository<int, Game> _gameRepo;
    
    private IRepository<int, Player> _playerRepo;
    
    private IRepository<int, Team> _teamRepo;

    public Service(IRepository<int, ActivePlayer> activePlayerRepo, IRepository<int, Game> gameRepo, IRepository<int, Player> playerRepo, IRepository<int, Team> teamRepo)
    {
        _activePlayerRepo = activePlayerRepo;
        _gameRepo = gameRepo;
        _playerRepo = playerRepo;
        _teamRepo = teamRepo;
    }

    public List<Player> GetAllPlayersFromTeam(Team team)
    {
        List<Player> allPlayers = _playerRepo.FindAll().ToList();
        IEnumerable<Player> playersFromTeam =
            allPlayers.Where(player => player.PlayerTeam == team.ID.ToString()).Select(player => player);
        return playersFromTeam.ToList();
    }

    public List<Team> GetAllTeams()
    {
        return _teamRepo.FindAll().ToList();
    }

    public List<Game> GetAllGames()
    {
        return _gameRepo.FindAll().ToList();
    }

    public Player GetPlayerByID(int id)
    {
        foreach (var pl in _playerRepo.FindAll())
        {
            if (pl.ID == id)
            {
                return pl;
            }
        }

        return null;
    }
    
    public List<ActivePlayer> GetAllActivePlayersFromGame(Game game, Team team)
    {
        List<ActivePlayer> allActivePlayers = _activePlayerRepo.FindAll().ToList().Where(activePlayer => activePlayer.PlayerType == PlayerType.ACTIVE).ToList();
        List<ActivePlayer> activePlayersFromGame = allActivePlayers.Where(ap => ap.GameID == game.ID).ToList();
        List<Player> allPlayers = _playerRepo.FindAll().ToList().Where(pl => pl.PlayerTeam == team.ID.ToString()).ToList();
        List<ActivePlayer> activePlayersFromTeamGame =
            (from ap in activePlayersFromGame join allP in allPlayers on ap.PlayerID equals allP.ID select ap).ToList();
        if (activePlayersFromTeamGame.Count == 0)
        {
            Console.WriteLine("No players from the given team played in the given game!\n");
        }
        return activePlayersFromTeamGame;
    }

    public List<Game> GamesBetweenDates(DateTime date1, DateTime date2)
    {
        List<Game> allGames = GetAllGames().Where(game => game.Date >= date1 && game.Date <= date2).Select(game => game).ToList();
        return allGames;
    }

    public List<ActivePlayer> ActivePlayersFromTeam(Team team)
    {
        List<ActivePlayer> activePlayers = _activePlayerRepo.FindAll().ToList();
        List<Player> players = _playerRepo.FindAll().ToList();
        var playersFromTeam = players.Where(p => int.Parse(p.PlayerTeam) == team.ID).ToList();
        var activePlayersFromTeam = (from ap in activePlayers join p in playersFromTeam on ap.PlayerID equals p.ID select ap).ToList();
        return activePlayersFromTeam.ToList();
    }
    
    public Tuple<int, int> GetScoreFromGame(Game game)
    {
        //use game 1 or 9
        var activePlayersFromHomeTeam = ActivePlayersFromTeam(game.HomeTeam);
        var activePlayersFromAwayTeam = ActivePlayersFromTeam(game.AwayTeam);
        if (activePlayersFromAwayTeam.Count == 0 || activePlayersFromHomeTeam.Count == 0)
        {
            throw new Exception("No one played that game!\n");

        }
        var scoreHomeTeam = activePlayersFromHomeTeam.Select(ap => ap.Score).Aggregate((a, b) => a + b);
        var scoreAwayTeam = activePlayersFromAwayTeam.Select(ap => ap.Score).Aggregate((a, b) => a + b);
        return new Tuple<int, int>(scoreHomeTeam, scoreAwayTeam);
    }
}