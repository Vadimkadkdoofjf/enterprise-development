using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;
using FitnessClub.Infrastructure.InMemory.Data;
using FitnessClub.Infrastructure.InMemory.Repositories.Base;

namespace FitnessClub.Infrastructure.InMemory.Repositories;

/// <summary>
/// Репозиторий специализаций с хранением данных в памяти.
/// </summary>
public class SpecializationRepository
    : InMemoryRepository<Specialization>, ISpecializationRepository
{
    /// <summary>
    /// Создаёт репозиторий специализаций.
    /// </summary>
    /// <param name="dataStore">Общее хранилище данных.</param>
    public SpecializationRepository(FitnessClubDataStore dataStore)
        : base(dataStore.Specializations)
    {
    }
}