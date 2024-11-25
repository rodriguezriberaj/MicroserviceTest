using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientDbContext _dbContext;

        public ClientRepository(ClientDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Client client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid clientId)
        {
            return await _dbContext.Clients
                .FirstOrDefaultAsync(c => c.ClientId == new ClientId(clientId));
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid clientId)
        {
            var client = await GetByIdAsync(clientId);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
