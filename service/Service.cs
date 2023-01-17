using BonusProject.model;
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
        List<Player> playersFromTeam = GetAllPlayersFromTeam(team);
        List<ActivePlayer> playersFromTeamGame = new List<ActivePlayer>();
        foreach (var pl in activePlayersFromGame)
        {
            foreach (var p in playersFromTeam)
            {
                if (pl.ID == p.ID)
                {
                    playersFromTeamGame.Add(pl);
                }
            }
        }
        return playersFromTeamGame;
    }

    public List<Game> GamesBetweenDates(DateTime date1, DateTime date2)
    {
        List<Game> allGames = GetAllGames().Where(game => game.Date >= date1 && game.Date <= date2).Select(game => game).ToList();
        return allGames;
    }

    public int GetScoreFromGame(Game game)
    {
        int Score = 0;

        List<ActivePlayer> allActivePlayers = _activePlayerRepo.FindAll().ToList().Where(activePlayer => activePlayer.PlayerType == PlayerType.ACTIVE).ToList();
        List<ActivePlayer> activePlayersFromGame = _activePlayerRepo.FindAll().ToList().Where(activePlayer => activePlayer.PlayerType == PlayerType.ACTIVE).ToList().Where(ap => ap.GameID == game.ID).ToList();
        
        
        return Score;
    }
}