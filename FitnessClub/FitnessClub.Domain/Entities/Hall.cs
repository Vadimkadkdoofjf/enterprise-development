namespace FitnessClub.Domain.Entities;

/// <summary>
/// Зал фитнес-клуба.
/// </summary>
public class Hall
{
    /// <summary>
    /// ID зала.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название зала.
    /// </summary>
    /// <example>Тренажёрный зал №1</example>
    public required string Name { get; set; }

    /// <summary>
    /// Вместимость(кол-во человек).
    /// </summary>
    public int Capacity { get; set; }
}