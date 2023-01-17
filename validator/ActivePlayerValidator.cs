using BonusProject.model;

namespace BonusProject.validator;

public class ActivePlayerValidator: IValidator<ActivePlayer>
{
    public void Validate(ActivePlayer activePlayer)
    {
        if (activePlayer.Score < 0)
        {
            throw new ValidatorException("Score can't be null!\n");
        }
    }
}