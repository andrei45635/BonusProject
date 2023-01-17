using BonusProject.model;

namespace BonusProject.validator;

public class PlayerValidator : IValidator<Player>
{
    public void Validate(Player player)
    {
        if (player.PlayerTeam == "")
        {
            throw new ValidatorException("Invalid team!\n");
        }
    }
}