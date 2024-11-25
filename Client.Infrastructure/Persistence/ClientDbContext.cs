using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Person> Persons { get; set; } 

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
