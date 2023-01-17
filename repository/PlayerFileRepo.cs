using BonusProject.model;
using BonusProject.validator;

namespace BonusProject.repository;

public class PlayerFileRepo: FileRepository<int, Player>
{
    public PlayerFileRepo(IValidator<Player> validator, string fileName) : base(validator, fileName, DelegateEntitiesFromFile.PlayerDelegate)
    {
    }
}