using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.DTOs.Specializations;
using FitnessClub.Contracts.Services.Specializations;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services.Specializations;

/// <summary>
/// Реализует операции для работы со специализациями тренеров.
/// </summary>
public class SpecializationService : ISpecializationService
{
    private readonly ISpecializationRepository _repository;

    /// <summary>
    /// Создаёт сервис специализаций.
    /// </summary>
    /// <param name="repository">Репозиторий специализаций.</param>
    public SpecializationService(ISpecializationRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<SpecializationDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();

        return items.Select(item => item.ToDto()).ToList();
    }

    /// <inheritdoc />
    public async Task<SpecializationDto?> GetByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);

        return item?.ToDto();
    }

    /// <inheritdoc />
    public async Task<SpecializationDto> CreateAsync(
        CreateSpecializationDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var specialization = new Specialization
        {
            Id = 0,
            Name = dto.Name,
            Description = dto.Description
        };

        var created = await _repository.AddAsync(specialization);

        return created.ToDto();
    }

    /// <inheritdoc />
    public async Task<bool> UpdateAsync(
        int id,
        UpdateSpecializationDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var specialization = await _repository.GetByIdAsync(id);

        if (specialization is null)
        {
            return false;
        }

        specialization.Name = dto.Name;
        specialization.Description = dto.Description;

        return await _repository.UpdateAsync(id, specialization);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}