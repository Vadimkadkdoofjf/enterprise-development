using FitnessClub.Contracts.DTOs.Clients;
using FitnessClub.Contracts.Services.Clients;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Api.Controllers.Clients;

/// <summary>
/// Предоставляет HTTP-операции для работы с клиентами фитнес-клуба.
/// </summary>
[ApiController]
[Route("api/clients")]
[Produces("application/json")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly ILogger<ClientsController> _logger;

    /// <summary>
    /// Создаёт контроллер клиентов.
    /// </summary>
    /// <param name="clientService">Сервис работы с клиентами.</param>
    /// <param name="logger">Журнал событий контроллера.</param>
    public ClientsController(
        IClientService clientService,
        ILogger<ClientsController> logger)
    {
        ArgumentNullException.ThrowIfNull(clientService);
        ArgumentNullException.ThrowIfNull(logger);

        _clientService = clientService;
        _logger = logger;
    }

    /// <summary>
    /// Возвращает список всех клиентов.
    /// </summary>
    /// <returns>Список клиентов.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ClientDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<ClientDto>>> GetAll()
    {
        var clients = await _clientService.GetAllAsync();

        return Ok(clients);
    }

    /// <summary>
    /// Возвращает клиента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор клиента.</param>
    /// <returns>Данные клиента.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientDto>> GetById(int id)
    {
        var client = await _clientService.GetByIdAsync(id);

        if (client is null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    /// <summary>
    /// Создаёт нового клиента.
    /// </summary>
    /// <param name="dto">Данные нового клиента.</param>
    /// <returns>Созданный клиент.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Create(
        [FromBody] CreateClientDto dto)
    {
        try
        {
            var client = await _clientService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = client.Id },
                client);
        }
        catch (ArgumentException exception)
        {
            _logger.LogWarning(
                exception,
                "Получены некорректные данные при создании клиента.");

            return BadRequest(new { message = exception.Message });
        }
    }

    /// <summary>
    /// Обновляет данные существующего клиента.
    /// </summary>
    /// <param name="id">Идентификатор клиента.</param>
    /// <param name="dto">Новые данные клиента.</param>
    /// <returns>Результат обновления.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateClientDto dto)
    {
        try
        {
            var updated = await _clientService.UpdateAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (ArgumentException exception)
        {
            _logger.LogWarning(
                exception,
                "Получены некорректные данные при обновлении клиента {ClientId}.",
                id);

            return BadRequest(new { message = exception.Message });
        }
    }

    /// <summary>
    /// Удаляет клиента.
    /// </summary>
    /// <param name="id">Идентификатор клиента.</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _clientService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}