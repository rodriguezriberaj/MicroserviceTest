
using Application.DTOs;
using Application.Services;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Service.Endpoints;

public static class ClientApiEndpoints
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/Clients",  async ([FromServices] ClientService service) => 
            {
                return await service.GetAllAsync();
            });

        routeBuilder.MapGet("/Clients/{clientId}", async([FromServices] ClientService service, Guid clientId) => 
            {
                var client = await service.GetclientByIdAsync(clientId);
                if(client is null){
                    return Results.NotFound(new { Message = "Client not found" });
                }
                return Results.Ok(client);
            });

        routeBuilder.MapPost("/Clients",
            async ([FromServices] ClientService service, CreateClientDto createClient) =>
            {
                await service.CreateClientAsync(createClient);

                return TypedResults.Created();
            });

        routeBuilder.MapPut("/Clients",
            async ([FromServices] ClientService service, UpdateClientDto updateClient) =>
            {
                await service.UpdateClientAsync(updateClient);

                return TypedResults.NoContent();
            });
        
        routeBuilder.MapDelete("/Clients/{clientId}",
            async ([FromServices] ClientService service, Guid clientId) =>
            {
                await service.DeleteClientAsync(clientId);

                return TypedResults.NoContent();
            });
    }
}