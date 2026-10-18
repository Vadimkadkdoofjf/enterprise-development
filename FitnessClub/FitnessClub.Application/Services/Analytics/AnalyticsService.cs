using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.DTOs.Analytics;
using FitnessClub.Contracts.DTOs.Clients;
using FitnessClub.Contracts.DTOs.Trainers;
using FitnessClub.Contracts.DTOs.Trainings;
using FitnessClub.Contracts.Services.Analytics;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services.Analytics;

/// <summary>
/// Реализует аналитические запросы фитнес-клуба.
/// </summary>
public class AnalyticsService : IAnalyticsService
{
    private readonly ITrainerRepository _trainerRepository;
    private readonly IClientRepository _clientRepository;
    private readonly ITrainingRepository _trainingRepository;
    private readonly IHallRepository _hallRepository;

    /// <summary>
    /// Создаёт сервис аналитики.
    /// </summary>
    public AnalyticsService(
        ITrainerRepository trainerRepository,
        IClientRepository clientRepository,
        ITrainingRepository trainingRepository,
        IHallRepository hallRepository)
    {
        ArgumentNullException.ThrowIfNull(trainerRepository);
        ArgumentNullException.ThrowIfNull(clientRepository);
        ArgumentNullException.ThrowIfNull(trainingRepository);
        ArgumentNullException.ThrowIfNull(hallRepository);

        _trainerRepository = trainerRepository;
        _clientRepository = clientRepository;
        _trainingRepository = trainingRepository;
        _hallRepository = hallRepository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TrainerDto>>
        GetExperiencedTrainersAsync()
    {
        var trainers = await _trainerRepository.GetAllAsync();

        return trainers
            .Where(trainer => trainer.WorkExperience >= 5)
            .Select(trainer => trainer.ToDto())
            .ToList();
    }

    /// <inheritdoc />
    public async Task<HallAvailabilityDto?> CheckHallAvailabilityAsync(
        int hallId)
    {
        var hall = await _hallRepository.GetByIdAsync(hallId);

        if (hall is null)
        {
            return null;
        }

        var trainings = await _trainingRepository.GetAllAsync();
        var now = DateTime.Now;

        var isOccupied = trainings.Any(training =>
            training.Hall.Id == hallId
            && training.StartTime <= now
            && training.StartTime.AddMinutes(training.DurationMinutes) > now);

        return new HallAvailabilityDto
        {
            HallId = hall.Id,
            HallName = hall.Name,
            IsAvailable = !isOccupied
        };
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ClientDto>>
        GetClientsWithExpiredSubscriptionsAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        var today = DateTime.Today;

        return clients
            .Where(client => client.SubscriptionEndDate.Date < today)
            .OrderBy(client => client.FullName)
            .Select(client => client.ToDto())
            .ToList();
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TrainingDto>>
        GetCurrentMonthTrainingsByHallAsync(int hallId)
    {
        var hall = await _hallRepository.GetByIdAsync(hallId);

        if (hall is null)
        {
            return [];
        }

        var trainings = await _trainingRepository.GetAllAsync();
        var now = DateTime.Now;

        return trainings
            .Where(training =>
                training.Hall.Id == hallId
                && training.StartTime.Year == now.Year
                && training.StartTime.Month == now.Month)
            .OrderBy(training => training.StartTime)
            .Select(training => training.ToDto())
            .ToList();
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TrainerDto>>
        GetTopFiveTrainersAsync()
    {
        var trainers = await _trainerRepository.GetAllAsync();
        var trainings = await _trainingRepository.GetAllAsync();

        return trainers
            .Select(trainer => new
            {
                Trainer = trainer,
                TrainingCount = trainings.Count(training =>
                    training.Trainer.Id == trainer.Id)
            })
            .Where(item => item.TrainingCount > 0)
            .OrderByDescending(item => item.TrainingCount)
            .ThenBy(item => item.Trainer.FullName)
            .Take(5)
            .Select(item => item.Trainer.ToDto())
            .ToList();
    }
}