namespace PlataformaRedencao.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int? id);
        Task<IReadOnlyCollection<T?>> GetAllAsync();
        Task<T> AddAsync(T entidade);
        Task<T> UpdateAsync(T entidade);
        Task<T> DeleteAsync(T entidade);
    }
}