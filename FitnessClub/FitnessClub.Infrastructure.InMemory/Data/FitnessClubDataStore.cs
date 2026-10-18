using FitnessClub.Domain.Entities;

namespace FitnessClub.Infrastructure.InMemory.Data;

/// <summary>
/// Единое хранилище данных фитнес-клуба в оперативной памяти.
/// </summary>
public class FitnessClubDataStore
{
    /// <summary>
    /// Коллекция клиентов фитнес-клуба.
    /// </summary>
    public List<Client> Clients { get; } = [];

    /// <summary>
    /// Коллекция тренеров фитнес-клуба.
    /// </summary>
    public List<Trainer> Trainers { get; } = [];

    /// <summary>
    /// Коллекция специализаций тренеров.
    /// </summary>
    public List<Specialization> Specializations { get; } = [];

    /// <summary>
    /// Коллекция залов фитнес-клуба.
    /// </summary>
    public List<Hall> Halls { get; } = [];

    /// <summary>
    /// Коллекция записей на тренировки.
    /// </summary>
    public List<Training> Trainings { get; } = [];
}