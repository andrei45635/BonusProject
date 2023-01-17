namespace BonusProject.validator;

public interface IValidator<E>
{
    void Validate(E entity);
}