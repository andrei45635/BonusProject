using BonusProject.model;
using BonusProject.validator;

namespace BonusProject.repository;

public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
{
    protected IDictionary<ID, E> Entities = new Dictionary<ID, E>();
    protected IValidator<E> Validator;

    public InMemoryRepository(IValidator<E> validator)
    {
        Validator = validator;
    }

    public IEnumerable<E> FindAll()
    {
        return this.Entities.Values.ToList();
    }

    public E Save(E e)
    {
        this.Validator.Validate(e);
        if (Entities.ContainsKey(e.ID))
        {
            return e;
        }
        this.Entities.Add(e.ID, e);
        return e;
    }
}