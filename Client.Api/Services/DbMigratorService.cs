using Infrastructure.Persistence;

namespace Services{
    public class DbMigratorService
    {
        private readonly IServiceProvider _serviceProvider;

        public DbMigratorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void MigrateAndSeedDatabase()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbMigrator = scope.ServiceProvider.GetRequiredService<DbMigrator>();
                dbMigrator.MigrateAndSeed();
            }
        }
    }
}

