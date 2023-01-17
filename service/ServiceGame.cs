using BonusProject.model;
using BonusProject.repository;

namespace BonusProject.service;

public class ServiceGame
{
    private IRepository<int, Game> Repository;

    public ServiceGame(IRepository<int, Game> repository)
    {
        Repository = repository;
    }

    public List<Game> GetAll()
    {
        return Repository.FindAll().ToList();
    }

    public Game Save(Game g)
    {
        return Repository.Save(g);
    }
}