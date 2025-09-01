using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations;

public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly IGenericRepository<T> _repository;
    public GenericUnitOfWork(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public IGenericRepository<T> Repository { get; }

    public virtual async Task<ActionResponse<T>> AddAsync(T entity)
    {
        return await _repository.AddAsync(entity);
    }

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public virtual async Task<ActionResponse<T>> GetAsync(int id)
    {
        return await _repository.GetAsync(id);
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        return await _repository.GetAsync();
    }

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }
}