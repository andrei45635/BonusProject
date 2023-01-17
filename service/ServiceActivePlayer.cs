using BonusProject.model;
using BonusProject.repository;

namespace BonusProject.service;

public class ServiceActivePlayer
{
    private IRepository<int, ActivePlayer> Repository;

    public ServiceActivePlayer(IRepository<int, ActivePlayer> repository)
    {
        Repository = repository;
    }

    public List<ActivePlayer> GetAll()
    {
        return Repository.FindAll().ToList();
    }

    public ActivePlayer Save(ActivePlayer ap)
    {
        return Repository.Save(ap);
    }
}