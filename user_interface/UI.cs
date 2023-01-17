using System.Globalization;
using BonusProject.model;
using BonusProject.repository;
using BonusProject.service;
using BonusProject.validator;

namespace BonusProject.user_interface;

public class UI
{
    private Service _service;

    public UI(Service service)
    {
        _service = service;
    }

    public int ShowMenu()
    {
        String input = Console.ReadLine();
        int user_input = int.Parse(input);
        Console.WriteLine("1. Sa se afiseze toti jucatorii unei echipe date\n");
        Console.WriteLine("2. Sa se afiseze toti jucatorii activi ai unei echipe de la un anumit meci\n");
        Console.WriteLine("3. Sa se afiseze toate meciurile dintr-o anumita perioada calendaristica\n");
        Console.WriteLine("4. Sa se determine si sa se afiseze scorul de la un anumit meci\n");
        return user_input;
    }

    public void RunProgram()
    {
        while (true)
        {
            int user_input = ShowMenu();
            switch (user_input)
            {
                case 1:
                    Task1();
                    break;    
            
                case 2:
                    Task2();
                    break;
                
                case 3:
                    Task3();
                    break;
            
                case 5:
                    return;
                
                default:
                    Console.WriteLine("Invalid command!\n");
                    break;
            }   
        }
    }
    
    public void Task1()
    {
        Console.WriteLine("Input a team: ");
        String tm = Console.ReadLine();
        int team = int.Parse(tm);
        Team theTeam = null;
        foreach (var t in _service.GetAllTeams())
        {
            if (team == t.ID)
            {
                theTeam = t;
            }
        }
        List<Player> resList = _service.GetAllPlayersFromTeam(theTeam);
        Console.WriteLine(resList.Count);
        foreach (var pl in resList)
        {
            Console.WriteLine(pl.StudentName);
        }
    }

    public void Task2()
    {
        Console.WriteLine("Input a team: ");
        String t = Console.ReadLine();
        int team = int.Parse(t);
        Team theTeam = null;
        
        Console.WriteLine("Input a game: ");
        String g = Console.ReadLine();
        int game = int.Parse(g);
        Game theGame = null;
        
        foreach (var tm in _service.GetAllTeams())
        {
            if (team == tm.ID)
            {
                theTeam = tm;
            }
        }

        foreach (var gm in _service.GetAllGames())
        {
            if (game == gm.ID)
            {
                theGame = gm;
            }
        }
        
        List<ActivePlayer> resList = _service.GetAllActivePlayersFromGame(theGame, theTeam);
        foreach (var ap in resList)
        {
            Player _player = _service.GetPlayerByID(ap.PlayerID);
            Console.WriteLine(_player.StudentName);
        }
    }

    public void Task3()
    {
        Console.WriteLine("Input the start date (dd/MM/yyyy): ");
        string startDate = Console.ReadLine();
        DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        
        Console.WriteLine("Input the end date (dd/MM/yyyy): ");
        string endDate = Console.ReadLine();
        DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        List<Game> resGames = _service.GamesBetweenDates(start, end);
        foreach (var game in resGames)
        {
            Console.WriteLine(game.ID + " ; " + game.Date);
        }
    }
}