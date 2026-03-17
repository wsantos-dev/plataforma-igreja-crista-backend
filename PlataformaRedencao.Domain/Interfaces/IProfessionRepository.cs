using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    /// <summary>
    /// Repository for persistence operations on <see cref="Profession"/> entities.
    /// </summary>
    public interface IProfessionRepository : IRepository<Profession>
    {
        Task<Profession?> GetByNameAsync(string? name);
    }
}