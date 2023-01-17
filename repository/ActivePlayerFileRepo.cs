using BonusProject.model;
using BonusProject.validator;

namespace BonusProject.repository;

public class ActivePlayerFileRepo : FileRepository<int, ActivePlayer>
{
    public ActivePlayerFileRepo(IValidator<ActivePlayer> validator, string fileName) : base(validator, fileName, DelegateEntitiesFromFile.ActivePlayerDelegate)
    {
    }
}