using BonusProject.model;

namespace BonusProject.validator;

public class TeamValidator: IValidator<Team>
{
    public void Validate(Team team)
    {
        if (team.TeamName == "")
        {
            throw new ValidatorException("Invalid team name!\n");
        }
    }
}