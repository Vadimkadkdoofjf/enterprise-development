using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.DTOs.Clients;
using FitnessClub.Contracts.Services.Clients;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Enums;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services.Clients;

/// <summary>
/// Реализует операции для работы с клиентами фитнес-клуба.
/// </summary>
public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    /// <summary>
    /// Создаёт сервис для работы с клиентами.
    /// </summary>
    /// <param name="clientRepository">Репозиторий клиентов.</param>
    public ClientService(IClientRepository clientRepository)
    {
        ArgumentNullException.ThrowIfNull(clientRepository);
        _clientRepository = clientRepository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ClientDto>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();

        return clients.Select(client => client.ToDto()).ToList();
    }

    /// <inheritdoc />
    public async Task<ClientDto?> GetByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        return client?.ToDto();
    }

    /// <inheritdoc />
    public async Task<ClientDto> CreateAsync(CreateClientDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var client = new Client
        {
            PassportNumber = dto.PassportNumber,
            FullName = dto.FullName,
            Gender = ParseGender(dto.Gender),
            BirthDate = dto.BirthDate,
            Phone = dto.Phone,
            SubscriptionStartDate = dto.SubscriptionStartDate,
            SubscriptionEndDate = dto.SubscriptionEndDate
        };

        var createdClient = await _clientRepository.AddAsync(client);

        return createdClient.ToDto();
    }

    /// <inheritdoc />
    public async Task<bool> UpdateAsync(int id, UpdateClientDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var existingClient = await _clientRepository.GetByIdAsync(id);

        if (existingClient is null)
        {
            return false;
        }

        existingClient.PassportNumber = dto.PassportNumber;
        existingClient.FullName = dto.FullName;
        existingClient.Gender = ParseGender(dto.Gender);
        existingClient.BirthDate = dto.BirthDate;
        existingClient.Phone = dto.Phone;
        existingClient.SubscriptionStartDate = dto.SubscriptionStartDate;
        existingClient.SubscriptionEndDate = dto.SubscriptionEndDate;

        return await _clientRepository.UpdateAsync(id, existingClient);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(int id)
    {
        return _clientRepository.DeleteAsync(id);
    }

    private static Gender ParseGender(string gender)
    {
        if (!Enum.TryParse<Gender>(gender, ignoreCase: true, out var result)
            || !Enum.IsDefined(result))
        {
            throw new ArgumentException(
                "Указано недопустимое значение пола. Используйте Male или Female.",
                nameof(gender));
        }

        return result;
    }
}