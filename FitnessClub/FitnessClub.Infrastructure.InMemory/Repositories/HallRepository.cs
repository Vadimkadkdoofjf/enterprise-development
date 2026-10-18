using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;
using FitnessClub.Infrastructure.InMemory.Data;
using FitnessClub.Infrastructure.InMemory.Repositories.Base;

namespace FitnessClub.Infrastructure.InMemory.Repositories;

/// <summary>
/// Репозиторий залов с хранением данных в памяти.
/// </summary>
public class HallRepository
    : InMemoryRepository<Hall>, IHallRepository
{
    /// <summary>
    /// Создаёт репозиторий залов.
    /// </summary>
    /// <param name="dataStore">Общее хранилище данных.</param>
    public HallRepository(FitnessClubDataStore dataStore)
        : base(dataStore.Halls)
    {
    }
}