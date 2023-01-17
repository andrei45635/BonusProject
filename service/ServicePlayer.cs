using BonusProject.model;
using BonusProject.repository;

namespace BonusProject.service;

public class ServicePlayer
{
    private IRepository<int, Player> Repository;

    public ServicePlayer(IRepository<int, Player> repository)
    {
        Repository = repository;
    }

    public List<Player> GetAll()
    {
        return Repository.FindAll().ToList();
    }

    public Player Save(Player p)
    {
        return Repository.Save(p);
    }
}