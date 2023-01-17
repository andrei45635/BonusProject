using BonusProject.model;
using BonusProject.validator;

namespace BonusProject.repository;

public class TeamFileRepo: FileRepository<int, Team>
{
    public TeamFileRepo(IValidator<Team> validator, string fileName) : base(validator, fileName, DelegateEntitiesFromFile.TeamDelegate)
    {
    }
}