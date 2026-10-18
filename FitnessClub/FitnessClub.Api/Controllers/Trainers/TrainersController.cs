
using FitnessClub.Contracts.DTOs.Trainers;
using FitnessClub.Contracts.Services;
using FitnessClub.Contracts.Services.Trainers;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Api.Controllers.Trainers;

/// <summary>
/// Предоставляет REST API для управления тренерами фитнес-клуба.
/// </summary>
[ApiController]
[Route("api/trainers")]
[Produces("application/json")]
public class TrainersController : ControllerBase
{
    private readonly ITrainerService _trainerService;
    private readonly ILogger<TrainersController> _logger;

    /// <summary>
    /// Создаёт контроллер тренеров.
    /// </summary>
    /// <param name="trainerService">Сервис управления тренерами.</param>
    /// <param name="logger">Журнал событий.</param>
    public TrainersController(
        ITrainerService trainerService,
        ILogger<TrainersController> logger)
    {
        _trainerService = trainerService;
        _logger = logger;
    }

    /// <summary>
    /// Возвращает список всех тренеров.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<TrainerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<TrainerDto>>> GetAllAsync()
    {
        var trainers = await _trainerService.GetAllAsync();

        return Ok(trainers);
    }

    /// <summary>
    /// Возвращает тренера по ID.
    /// </summary>
    /// <param name="id">ID тренера.</param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(TrainerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TrainerDto>> GetByIdAsync(int id)
    {
        var trainer = await _trainerService.GetByIdAsync(id);

        if (trainer is null)
        {
            return NotFound();
        }

        return Ok(trainer);
    }

    /// <summary>
    /// Создаёт нового тренера.
    /// </summary>
    /// <param name="dto">Данные нового тренера.</param>
    [HttpPost]
    [ProducesResponseType(typeof(TrainerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainerDto>> CreateAsync(
        [FromBody] CreateTrainerDto dto)
    {
        try
        {
            var trainer = await _trainerService.CreateAsync(dto);

            _logger.LogInformation(
                "Создан тренер с IDом {TrainerId}.",
                trainer.Id);

            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = trainer.Id },
                trainer);
        }
        catch (ArgumentException exception)
        {
            _logger.LogWarning(exception, "Некорректные данные нового тренера.");

            return BadRequest(new { message = exception.Message });
        }
    }

    /// <summary>
    /// Обновляет данные существующего тренера.
    /// </summary>
    /// <param name="id">ID тренера.</param>
    /// <param name="dto">Новые данные тренера.</param>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(
        int id,
        [FromBody] UpdateTrainerDto dto)
    {
        try
        {
            var updated = await _trainerService.UpdateAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            _logger.LogInformation(
                "Обновлён тренер с IDом {TrainerId}.",
                id);

            return NoContent();
        }
        catch (ArgumentException exception)
        {
            _logger.LogWarning(
                exception,
                "Некорректные данные тренера с IDом {TrainerId}.",
                id);

            return BadRequest(new { message = exception.Message });
        }
    }

    /// <summary>
    /// Удаляет тренера.
    /// </summary>
    /// <param name="id">ID тренера.</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var deleted = await _trainerService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        _logger.LogInformation(
            "Удалён тренер с IDом {TrainerId}.",
            id);

        return NoContent();
    }
}