using FitnessClub.Contracts.DTOs.Halls;
using FitnessClub.Contracts.Services.Halls;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Api.Controllers.Halls;

/// <summary>
/// Предоставляет HTTP-операции для работы с залами.
/// </summary>
[ApiController]
[Route("api/halls")]
[Produces("application/json")]
public class HallsController : ControllerBase
{
    private readonly IHallService _service;

    /// <summary>
    /// Создаёт контроллер залов.
    /// </summary>
    /// <param name="service">Сервис залов.</param>
    public HallsController(IHallService service)
    {
        ArgumentNullException.ThrowIfNull(service);
        _service = service;
    }

    /// <summary>Возвращает все залы.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<HallDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<HallDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    /// <summary>Возвращает зал по идентификатору.</summary>
    /// <param name="id">Идентификатор зала.</param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(HallDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HallDto>> GetById(int id)
    {
        var hall = await _service.GetByIdAsync(id);

        return hall is null ? NotFound() : Ok(hall);
    }

    /// <summary>Создаёт зал.</summary>
    /// <param name="dto">Данные нового зала.</param>
    [HttpPost]
    [ProducesResponseType(typeof(HallDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HallDto>> Create([FromBody] CreateHallDto dto)
    {
        var hall = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = hall.Id }, hall);
    }

    /// <summary>Обновляет зал.</summary>
    /// <param name="id">Идентификатор зала.</param>
    /// <param name="dto">Новые данные зала.</param>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateHallDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        return updated ? NoContent() : NotFound();
    }

    /// <summary>Удаляет зал.</summary>
    /// <param name="id">Идентификатор зала.</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        return deleted ? NoContent() : NotFound();
    }
}