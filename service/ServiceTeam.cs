using BonusProject.model;
using BonusProject.repository;

namespace BonusProject.service;

public class ServiceTeam
{
    private IRepository<int, Team> Repository;

    public ServiceTeam(IRepository<int, Team> repository)
    {
        Repository = repository;
    }

    public List<Team> GetAll()
    {
        return Repository.FindAll().ToList();
    }

    public Team Save(Team t)
    {
        return Repository.Save(t);
    }
}