using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;
using FitnessClub.Infrastructure.InMemory.Data;
using FitnessClub.Infrastructure.InMemory.Repositories.Base;

namespace FitnessClub.Infrastructure.InMemory.Repositories;

/// <summary>
/// Репозиторий клиентов с хранением данных в памяти.
/// </summary>
public class ClientRepository
    : InMemoryRepository<Client>, IClientRepository
{
    /// <summary>
    /// Создаёт репозиторий клиентов.
    /// </summary>
    /// <param name="dataStore">Общее хранилище данных.</param>
    public ClientRepository(FitnessClubDataStore dataStore)
        : base(dataStore.Clients)
    {
    }
}