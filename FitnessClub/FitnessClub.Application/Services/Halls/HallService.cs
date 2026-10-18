using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.DTOs.Halls;
using FitnessClub.Contracts.Services.Halls;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services.Halls;

/// <summary>
/// Реализует операции для работы с залами фитнес-клуба.
/// </summary>
public class HallService : IHallService
{
    private readonly IHallRepository _repository;

    /// <summary>
    /// Создаёт сервис залов.
    /// </summary>
    /// <param name="repository">Репозиторий залов.</param>
    public HallService(IHallRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<HallDto>> GetAllAsync()
    {
        var halls = await _repository.GetAllAsync();

        return halls.Select(hall => hall.ToDto()).ToList();
    }

    /// <inheritdoc />
    public async Task<HallDto?> GetByIdAsync(int id)
    {
        var hall = await _repository.GetByIdAsync(id);

        return hall?.ToDto();
    }

    /// <inheritdoc />
    public async Task<HallDto> CreateAsync(CreateHallDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var hall = new Hall
        {
            Id = 0,
            Name = dto.Name,
            Capacity = dto.Capacity
        };

        var created = await _repository.AddAsync(hall);

        return created.ToDto();
    }

    /// <inheritdoc />
    public async Task<bool> UpdateAsync(int id, UpdateHallDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var hall = await _repository.GetByIdAsync(id);

        if (hall is null)
        {
            return false;
        }

        hall.Name = dto.Name;
        hall.Capacity = dto.Capacity;

        return await _repository.UpdateAsync(id, hall);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}