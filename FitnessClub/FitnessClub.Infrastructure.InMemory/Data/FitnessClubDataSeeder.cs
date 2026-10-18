using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Enums;

namespace FitnessClub.Infrastructure.InMemory.Data;

/// <summary>
/// Заполняет хранилище начальными данными для проверки приложения.
/// </summary>
public static class FitnessClubDataSeeder
{
    /// <summary>
    /// Добавляет тестовые специализации, залы, клиентов,
    /// тренеров и тренировки, если хранилище пустое.
    /// </summary>
    /// <param name="store">Хранилище фитнес-клуба.</param>
    public static void Seed(FitnessClubDataStore store)
    {
        ArgumentNullException.ThrowIfNull(store);

        if (store.Specializations.Count > 0
            || store.Halls.Count > 0
            || store.Clients.Count > 0
            || store.Trainers.Count > 0
            || store.Trainings.Count > 0)
        {
            return;
        }

        var strength = new Specialization
        {
            Id = 1,
            Name = "Силовой тренинг",
            Description = "Развитие силы и мышечной массы."
        };

        var fitness = new Specialization
        {
            Id = 2,
            Name = "Общий фитнес",
            Description = "Общая физическая подготовка."
        };

        store.Specializations.AddRange([strength, fitness]);

        var hall1 = new Hall
        {
            Id = 1,
            Name = "Тренажёрный зал",
            Capacity = 20
        };

        var hall2 = new Hall
        {
            Id = 2,
            Name = "Зал групповых занятий",
            Capacity = 15
        };

        store.Halls.AddRange([hall1, hall2]);

        var client1 = new Client
        {
            Id = 1,
            PassportNumber = "1234 567890",
            FullName = "Иванов Иван Иванович",
            Gender = Gender.Male,
            BirthDate = new DateTime(1998, 5, 10),
            Phone = "+79991111111",
            SubscriptionStartDate = DateTime.Today.AddMonths(-2),
            SubscriptionEndDate = DateTime.Today.AddMonths(1)
        };

        var client2 = new Client
        {
            Id = 2,
            PassportNumber = "4321 098765",
            FullName = "Петрова Анна Сергеевна",
            Gender = Gender.Female,
            BirthDate = new DateTime(2000, 8, 20),
            Phone = "+79992222222",
            SubscriptionStartDate = DateTime.Today.AddMonths(-6),
            SubscriptionEndDate = DateTime.Today.AddDays(-10)
        };

        store.Clients.AddRange([client1, client2]);

        var trainer1 = new Trainer
        {
            Id = 1,
            PassportNumber = "1111 222233",
            FullName = "Смирнов Алексей Олегович",
            Gender = Gender.Male,
            BirthDate = new DateTime(1988, 3, 12),
            Specialization = strength,
            WorkExperience = 8
        };

        var trainer2 = new Trainer
        {
            Id = 2,
            PassportNumber = "2222 333344",
            FullName = "Кузнецова Мария Игоревна",
            Gender = Gender.Female,
            BirthDate = new DateTime(1995, 11, 2),
            Specialization = fitness,
            WorkExperience = 3
        };

        store.Trainers.AddRange([trainer1, trainer2]);

        var training1 = new Training
        {
            Id = 1,
            Client = client1,
            Trainer = trainer1,
            Hall = hall1,
            StartTime = DateTime.Now.AddHours(-1),
            DurationMinutes = 60,
            IsTrial = false
        };

        var training2 = new Training
        {
            Id = 2,
            Client = client2,
            Trainer = trainer2,
            Hall = hall2,
            StartTime = DateTime.Today.AddDays(2).AddHours(12),
            DurationMinutes = 60,
            IsTrial = true
        };

        store.Trainings.AddRange([training1, training2]);
    }
}