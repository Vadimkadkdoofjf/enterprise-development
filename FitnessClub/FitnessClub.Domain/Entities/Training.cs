namespace FitnessClub.Domain.Entities;

/// <summary>
/// Запись клиента на персональное занятие с тренером.
/// </summary>
public class Training
{
    /// <summary>
    /// ID записи.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Клиент, записанный на занятие.
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    /// Тренер, проводящий занятие.
    /// </summary>
    public required Trainer Trainer { get; set; }

    /// <summary>
    /// Зал, в котором проводится занятие.
    /// </summary>
    public required Hall Hall { get; set; }

    /// <summary>
    /// Дата и время начала занятия.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Продолжительность занятия в минутах.
    /// </summary>
    public int DurationMinutes { get; set; }

    /// <summary>
    /// Признак пробного занятия.
    /// </summary>
    public bool IsTrial { get; set; }
}