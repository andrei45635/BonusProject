using System.ComponentModel.DataAnnotations;
using BonusProject.model;

namespace BonusProject.validator;

public class GameValidator : IValidator<Game>
{
    public void Validate(Game game)
    {
        if (game.Date > DateTime.Now)
        {
            throw new ValidationException("Invalid date!\n");
        }
    }
}