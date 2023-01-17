namespace BonusProject.validator;

public class ValidatorException : ApplicationException
{
    public ValidatorException(string? message) : base(message)
    {
    }
}