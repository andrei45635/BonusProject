using BonusProject.model;

namespace BonusProject.repository;

public interface IRepository<ID, E> where E : Entity<ID>
{
    
    IEnumerable<E> FindAll();
    
    E Save(E e);
}