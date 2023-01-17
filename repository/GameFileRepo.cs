using BonusProject.model;
using BonusProject.validator;

namespace BonusProject.repository;

public class GameFileRepo: FileRepository<int, Game>
{
    public GameFileRepo(IValidator<Game> validator, string fileName) : base(validator, fileName, DelegateEntitiesFromFile.GameDelegate)
    {
    }
}