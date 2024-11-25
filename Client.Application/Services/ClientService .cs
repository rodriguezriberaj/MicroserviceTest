using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using System.Linq;
namespace Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateClientAsync(CreateClientDto dto)
        {
            var existingClient = _clientRepository.GetByIdAsync(dto.ClientId);

            if(existingClient != null){
                throw new InvalidDataException($"Client with ID {dto.ClientId} already exist.");
            }

            var client = new Client(
                name: dto.Name,
                gender: Enum.Parse<Gender>(dto.Gender, true),
                age: dto.Age,
                identification: dto.Identification,
                address: dto.Address,
                phoneNumber: dto.PhoneNumber,
                clientId: dto.ClientId,
                username: dto.Username,
                password: dto.Password
            );

            await _clientRepository.AddAsync(client);
        }

        public async Task UpdateClientAsync(UpdateClientDto dto)
        {
            var client = await _clientRepository.GetByIdAsync(dto.ClientId);
            if (client is not Client existingClient){
                throw new ArgumentException($"Client with ID {dto.ClientId} does not exist.");
            }
                
            existingClient.UpdateBasicInfo(dto.Address, dto.PhoneNumber);

            await _clientRepository.UpdateAsync(existingClient);
        }

        public async Task DeleteClientAsync(Guid clientId)
        {
            await _clientRepository.DeleteAsync(clientId);
        }

        public async Task<ClientDto?> GetclientByIdAsync(Guid clientId)
        {
            var client =  await _clientRepository.GetByIdAsync(clientId);
            
            if (client is null){
                return null;
            }

            return new ClientDto(){
                Name = client.Name.Value,
                Address = client.Address.Value,
                Password = client.Password.Value,
                PhoneNumber = client.PhoneNumber.Value,
                Username = client.Username.Value
            };
        }

        public async Task<List<ClientDto>> GetAllAsync()
        {
            var clients =  await _clientRepository.GetAllAsync();
            
           return clients.ToArray().Select(client=> new ClientDto(){
                Name = client.Name.Value,
                ClientId = client.ClientId.Value,
                Address = client.Address.Value,
                Password = client.Password.Value,
                PhoneNumber = client.PhoneNumber.Value,
                Username = client.Username.Value}).ToList();
        }

    }
}
