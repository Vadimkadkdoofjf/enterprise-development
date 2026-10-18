using FitnessClub.Contracts.DTOs.Clients;
using FitnessClub.Domain.Entities;

namespace FitnessClub.Application.Mapping;

/// <summary>
/// Выполняет преобразование клиента в DTO.
/// </summary>
public static class ClientMapping
{
    /// <summary>
    /// Преобразует сущность клиента в объект передачи данных.
    /// </summary>
    /// <param name="client">Клиент фитнес-клуба.</param>
    /// <returns>DTO клиента.</returns>
    public static ClientDto ToDto(this Client client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return new ClientDto
        {
            Id = client.Id,
            PassportNumber = client.PassportNumber,
            FullName = client.FullName,
            Gender = client.Gender.ToString(),
            BirthDate = client.BirthDate,
            Phone = client.Phone,
            SubscriptionStartDate = client.SubscriptionStartDate,
            SubscriptionEndDate = client.SubscriptionEndDate
        };
    }
}