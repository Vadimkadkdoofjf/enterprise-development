using FitnessClub.Contracts.DTOs.Trainings;
using FitnessClub.Contracts.Services.Trainings;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Api.Controllers.Trainings;

/// <summary>
/// Предоставляет HTTP-операции для работы с тренировками.
/// </summary>
[ApiController]
[Route("api/trainings")]
[Produces("application/json")]
public class TrainingsController : ControllerBase
{
    private readonly ITrainingService _service;
    private readonly ILogger<TrainingsController> _logger;

    /// <summary>
    /// Создаёт контроллер тренировок.
    /// </summary>
    public TrainingsController(
        ITrainingService service,
        ILogger<TrainingsController> logger)
    {
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(logger);

        _service = service;
        _logger = logger;
    }

    /// <summary>Возвращает все записи на тренировки.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<TrainingDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<TrainingDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    /// <summary>Возвращает запись по IDу.</summary>
    /// <param name="id">ID тренировки.</param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(TrainingDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TrainingDto>> GetById(int id)
    {
        var training = await _service.GetByIdAsync(id);

        return training is null ? NotFound() : Ok(training);
    }

    /// <summary>Создаёт запись на тренировку.</summary>
    /// <param name="dto">Данные тренировки.</param>
    [HttpPost]
    [ProducesResponseType(typeof(TrainingDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainingDto>> Create(
        [FromBody] CreateTrainingDto dto)
    {
        try
        {
            var training = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = training.Id },
                training);
        }
        catch (ArgumentException exception)
        {
            _logger.LogWarning(exception, "Некорректные данные тренировки.");

            return BadRequest(new { message = exception.Message });
        }
    }

    /// <summary>Обновляет запись на тренировку.</summary>
    /// <param name="id">ID тренировки.</param>
    /// <param name="dto">Новые данные тренировки.</param>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateTrainingDto dto)
    {
        try
        {
            var updated = await _service.UpdateAsync(id, dto);

            return updated ? NoContent() : NotFound();
        }
        catch (ArgumentException exception)
        {
            _logger.LogWarning(
                exception,
                "Некорректные данные тренировки {TrainingId}.",
                id);

            return BadRequest(new { message = exception.Message });
        }
    }

    /// <summary>Удаляет запись на тренировку.</summary>
    /// <param name="id">ID тренировки.</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        return deleted ? NoContent() : NotFound();
    }
}