using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence
{
    public class DbMigrator
    {
        private readonly ClientDbContext _context;

        public DbMigrator(ClientDbContext context)
        {
            _context = context;
        }

        public void MigrateAndSeed()
        {
            try
            {
                _context.Database.Migrate();

                var dbInitializer = new DbInitializer(_context);
                dbInitializer.Initialize();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
