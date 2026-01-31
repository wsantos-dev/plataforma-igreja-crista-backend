namespace PlataformaRedencao.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> ObterPorIdAsync(int? id);
        Task<IReadOnlyCollection<T?>> ObterTodosAsync();
        Task<T> AdicionarAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<T> Excluir(T entidade);
    }
}