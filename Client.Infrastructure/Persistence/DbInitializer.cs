using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Persistence
{
    public class DbInitializer
{
    private readonly ClientDbContext _context;

    public DbInitializer(ClientDbContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        if (!_context.Clients.Any())
        {
            _context.Clients.AddRange(
                new Client("Carlos Contreras", Gender.Male, 30, "ID12345","123 Main St","1234567890",Guid.NewGuid(),"client1", "password1"),
                new Client("Jose Medina", Gender.Female, 25, "ID12346","456 Elm St","1234567891",Guid.NewGuid(),"client2", "password2"),
                new Client("Manuel Saavedra", Gender.Female, 40, "ID12347","789 Oak St","123467892",Guid.NewGuid(),"client3", "password3"),
                new Client("Marlon Martinez", Gender.Male, 35, "ID12348","101 Pine St","5223456893",Guid.NewGuid(),"client4", "password4"),
                new Client("Claudio Bonilla", Gender.Male, 28, "ID12349","202 Maple St","8784567894",Guid.NewGuid(),"client5", "password5")
            );
        }

        _context.SaveChanges();
    }
}

}
