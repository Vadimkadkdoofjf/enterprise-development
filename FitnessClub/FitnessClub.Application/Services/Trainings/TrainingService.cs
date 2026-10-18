using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.DTOs.Trainings;
using FitnessClub.Contracts.Services.Trainings;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services.Trainings;

/// <summary>
/// Реализует операции для работы с записями на тренировки.
/// </summary>
public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IClientRepository _clientRepository;
    private readonly ITrainerRepository _trainerRepository;
    private readonly IHallRepository _hallRepository;

    /// <summary>
    /// Создаёт сервис тренировок.
    /// </summary>
    public TrainingService(
        ITrainingRepository trainingRepository,
        IClientRepository clientRepository,
        ITrainerRepository trainerRepository,
        IHallRepository hallRepository)
    {
        ArgumentNullException.ThrowIfNull(trainingRepository);
        ArgumentNullException.ThrowIfNull(clientRepository);
        ArgumentNullException.ThrowIfNull(trainerRepository);
        ArgumentNullException.ThrowIfNull(hallRepository);

        _trainingRepository = trainingRepository;
        _clientRepository = clientRepository;
        _trainerRepository = trainerRepository;
        _hallRepository = hallRepository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TrainingDto>> GetAllAsync()
    {
        var trainings = await _trainingRepository.GetAllAsync();

        return trainings.Select(training => training.ToDto()).ToList();
    }

    /// <inheritdoc />
    public async Task<TrainingDto?> GetByIdAsync(int id)
    {
        var training = await _trainingRepository.GetByIdAsync(id);

        return training?.ToDto();
    }

    /// <inheritdoc />
    public async Task<TrainingDto> CreateAsync(CreateTrainingDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var client = await _clientRepository.GetByIdAsync(dto.ClientId);
        var trainer = await _trainerRepository.GetByIdAsync(dto.TrainerId);
        var hall = await _hallRepository.GetByIdAsync(dto.HallId);

        if (client is null)
        {
            throw new ArgumentException("Клиент не найден.", nameof(dto));
        }

        if (trainer is null)
        {
            throw new ArgumentException("Тренер не найден.", nameof(dto));
        }

        if (hall is null)
        {
            throw new ArgumentException("Зал не найден.", nameof(dto));
        }

        var training = new Training
        {
            Id = 0,
            Client = client,
            Trainer = trainer,
            Hall = hall,
            StartTime = dto.StartTime,
            DurationMinutes = dto.DurationMinutes,
            IsTrial = dto.IsTrial
        };

        var created = await _trainingRepository.AddAsync(training);

        return created.ToDto();
    }

    /// <inheritdoc />
    public async Task<bool> UpdateAsync(int id, UpdateTrainingDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var training = await _trainingRepository.GetByIdAsync(id);

        if (training is null)
        {
            return false;
        }

        var client = await _clientRepository.GetByIdAsync(dto.ClientId);
        var trainer = await _trainerRepository.GetByIdAsync(dto.TrainerId);
        var hall = await _hallRepository.GetByIdAsync(dto.HallId);

        if (client is null || trainer is null || hall is null)
        {
            throw new ArgumentException(
                "Клиент, тренер или зал не найдены.",
                nameof(dto));
        }

        training.Client = client;
        training.Trainer = trainer;
        training.Hall = hall;
        training.StartTime = dto.StartTime;
        training.DurationMinutes = dto.DurationMinutes;
        training.IsTrial = dto.IsTrial;

        return await _trainingRepository.UpdateAsync(id, training);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(int id)
    {
        return _trainingRepository.DeleteAsync(id);
    }
}