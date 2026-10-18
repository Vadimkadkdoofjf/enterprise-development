using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.DTOs.Trainers;
using FitnessClub.Contracts.Services.Trainers;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Enums;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services.Trainers;

/// <summary>
/// Реализует операции для работы с тренерами.
/// </summary>
public class TrainerService : ITrainerService
{
    private readonly ITrainerRepository _trainerRepository;
    private readonly ISpecializationRepository _specializationRepository;

    /// <summary>
    /// Создаёт сервис тренеров.
    /// </summary>
    public TrainerService(
        ITrainerRepository trainerRepository,
        ISpecializationRepository specializationRepository)
    {
        ArgumentNullException.ThrowIfNull(trainerRepository);
        ArgumentNullException.ThrowIfNull(specializationRepository);

        _trainerRepository = trainerRepository;
        _specializationRepository = specializationRepository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TrainerDto>> GetAllAsync()
    {
        var trainers = await _trainerRepository.GetAllAsync();
        return trainers.Select(trainer => trainer.ToDto()).ToList();
    }

    /// <inheritdoc />
    public async Task<TrainerDto?> GetByIdAsync(int id)
    {
        var trainer = await _trainerRepository.GetByIdAsync(id);
        return trainer?.ToDto();
    }

    /// <inheritdoc />
    public async Task<TrainerDto> CreateAsync(CreateTrainerDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var specialization = await _specializationRepository
            .GetByIdAsync(dto.SpecializationId);

        if (specialization is null)
        {
            throw new ArgumentException(
                "Указанная специализация не найдена.",
                nameof(dto));
        }

        var trainer = new Trainer
        {
            PassportNumber = dto.PassportNumber,
            FullName = dto.FullName,
            Gender = ParseGender(dto.Gender),
            BirthDate = dto.BirthDate,
            Specialization = specialization,
            WorkExperience = dto.WorkExperienceYears
        };

        var createdTrainer = await _trainerRepository.AddAsync(trainer);
        return createdTrainer.ToDto();
    }

    /// <inheritdoc />
    public async Task<bool> UpdateAsync(int id, UpdateTrainerDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var trainer = await _trainerRepository.GetByIdAsync(id);

        if (trainer is null)
        {
            return false;
        }

        var specialization = await _specializationRepository
            .GetByIdAsync(dto.SpecializationId);

        if (specialization is null)
        {
            throw new ArgumentException(
                "Указанная специализация не найдена.",
                nameof(dto));
        }

        trainer.PassportNumber = dto.PassportNumber;
        trainer.FullName = dto.FullName;
        trainer.Gender = ParseGender(dto.Gender);
        trainer.BirthDate = dto.BirthDate;
        trainer.Specialization = specialization;
        trainer.WorkExperience = dto.WorkExperienceYears;

        return await _trainerRepository.UpdateAsync(id, trainer);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(int id)
    {
        return _trainerRepository.DeleteAsync(id);
    }

    private static Gender ParseGender(string gender)
    {
        if (!Enum.TryParse<Gender>(gender, true, out var result)
            || !Enum.IsDefined(result))
        {
            throw new ArgumentException(
                "Допустимые значения пола: Male или Female.",
                nameof(gender));
        }

        return result;
    }
}