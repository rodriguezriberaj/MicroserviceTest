using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClientRepository
    {
        Task AddAsync(Client client);
        Task<Client> GetByIdAsync(Guid clientId);
        Task<IEnumerable<Client?>> GetAllAsync();
        Task UpdateAsync(Client client);
        Task DeleteAsync(Guid clientId);
    }
}