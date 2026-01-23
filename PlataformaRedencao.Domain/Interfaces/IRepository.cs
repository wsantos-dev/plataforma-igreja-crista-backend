namespace PlataformaRedencao.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> ObterPorIdAsync(int id);
        Task<IReadOnlyCollection<T>> ObterTodosAsync();
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task Excluir(T entidade);
    }
}