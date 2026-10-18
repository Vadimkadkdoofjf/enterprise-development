using System.ComponentModel.DataAnnotations;

namespace FitnessClub.Contracts.DTOs.Halls;

/// <summary>
/// Данные для создания зала.
/// </summary>
public class CreateHallDto
{
    /// <summary>
    /// Название зала.
    /// </summary>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    /// Вместимость зала.
    /// </summary>
    [Range(1, 1000)]
    public int Capacity { get; set; }
}