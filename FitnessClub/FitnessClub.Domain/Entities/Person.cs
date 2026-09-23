using FitnessClub.Domain.Enums;

namespace FitnessClub.Domain.Entities;

/// <summary>
/// Базовый класс для человека.
/// </summary>
public abstract class Person
{
    /// <summary>
    /// Номер паспорта.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// ФИО.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Пол.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateTime BirthDate { get; set; }
}