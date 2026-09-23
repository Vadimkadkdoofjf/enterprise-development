namespace FitnessClub.Domain.Entities;

/// <summary>
/// Клиент фитнес-клуба.
/// </summary>
public class Client : Person
{
    /// <summary>
    /// Номер телефона клиента.
    /// </summary>
    public required string Phone { get; set; }

    /// <summary>
    /// Дата начала действия абонемента.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата окончания действия абонемента.
    /// </summary>
    public DateTime
        EndDate
    { get; set; }
}