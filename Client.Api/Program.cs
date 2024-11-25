using Application.Services;
using Basket.Service.Endpoints;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<DbMigrator>();
builder.Services.AddScoped<ClientService>();

builder.Services.AddDbContext<ClientDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbMigrator = scope.ServiceProvider.GetRequiredService<DbMigrator>();
    dbMigrator.MigrateAndSeed();
}

app.RegisterEndpoints();

app.Run();
