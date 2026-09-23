using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Enums;

namespace FitnessClub.Tests;

/// <summary>
/// Тестовые данные для проверки LINQ-запросов.
/// </summary>
public class QueriesTestFixture
{
    /// <summary>
    /// Список специализаций.
    /// </summary>
    public List<Specialization> Specializations { get; }

    /// <summary>
    /// Список залов.
    /// </summary>
    public List<Hall> Halls { get; }

    /// <summary>
    /// Список клиентов.
    /// </summary>
    public List<Client> Clients { get; }

    /// <summary>
    /// Список тренеров.
    /// </summary>
    public List<Trainer> Trainers { get; }

    /// <summary>
    /// Список записей на занятия.
    /// </summary>
    public List<Training> Trainings { get; }

    /// <summary>
    /// Инициализирует тестовые данные.
    /// </summary>
    public QueriesTestFixture()
    {
        Specializations =
        [
            new Specialization
            {
                Id = 1,
                Name = "Персональный тренинг",
                Description = "Индивидуальные тренировки"
            },
            new Specialization
            {
                Id = 2,
                Name = "Силовой тренинг",
                Description = "Развитие силы и выносливости"
            },
            new Specialization
            {
                Id = 3,
                Name = "Функциональный тренинг",
                Description = "Функциональные упражнения"
            },
            new Specialization
            {
                Id = 4,
                Name = "Йога",
                Description = "Йога и растяжка"
            },
            new Specialization
            {
                Id = 5,
                Name = "Пилатес",
                Description = "Пилатес"
            },
            new Specialization
            {
                Id = 6,
                Name = "Кардио",
                Description = "Кардиотренировки"
            },
            new Specialization
            {
                Id = 7,
                Name = "Кроссфит",
                Description = "Высокоинтенсивные тренировки"
            },
            new Specialization
            {
                Id = 8,
                Name = "Стретчинг",
                Description = "Растяжка"
            },
            new Specialization
            {
                Id = 9,
                Name = "Бокс",
                Description = "Бокс и единоборства"
            },
            new Specialization
            {
                Id = 10,
                Name = "Реабилитационный тренинг",
                Description = "Восстановительные тренировки"
            }
        ];

        Halls =
        [
            new Hall
            {
                Id = 1,
                Name = "Тренажёрный зал №1",
                Capacity = 20
            },
            new Hall
            {
                Id = 2,
                Name = "Тренажёрный зал №2",
                Capacity = 20
            },
            new Hall
            {
                Id = 3,
                Name = "Зал групповых программ №1",
                Capacity = 25
            },
            new Hall
            {
                Id = 4,
                Name = "Зал групповых программ №2",
                Capacity = 25
            },
            new Hall
            {
                Id = 5,
                Name = "Зал йоги",
                Capacity = 15
            },
            new Hall
            {
                Id = 6,
                Name = "Зал пилатеса",
                Capacity = 15
            },
            new Hall
            {
                Id = 7,
                Name = "Кардио-зал",
                Capacity = 30
            },
            new Hall
            {
                Id = 8,
                Name = "Зал кроссфита",
                Capacity = 20
            },
            new Hall
            {
                Id = 9,
                Name = "Боксёрский зал",
                Capacity = 15
            },
            new Hall
            {
                Id = 10,
                Name = "Реабилитационный зал",
                Capacity = 10
            }
        ];

        Clients =
        [
            new Client
            {
                PassportNumber = "1000 000001",
                FullName = "Иванов Иван Иванович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1995, 3, 12),
                Phone = "+79990000001",
                StartDate = new DateTime(2026, 1, 1),
                EndDate = new DateTime(2026, 12, 31)
            },
            new Client
            {
                PassportNumber = "1000 000002",
                FullName = "Петров Пётр Петрович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1998, 5, 20),
                Phone = "+79990000002",
                StartDate = new DateTime(2026, 2, 1),
                EndDate = new DateTime(2026, 11, 30)
            },
            new Client
            {
                PassportNumber = "1000 000003",
                FullName = "Сидорова Анна Сергеевна",
                Gender = Gender.Female,
                BirthDate = new DateTime(2000, 7, 10),
                Phone = "+79990000003",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 12, 31)
            },
            new Client
            {
                PassportNumber = "1000 000004",
                FullName = "Кузнецов Алексей Викторович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1992, 9, 15),
                Phone = "+79990000004",
                StartDate = new DateTime(2025, 3, 1),
                EndDate = new DateTime(2026, 3, 31)
            },
            new Client
            {
                PassportNumber = "1000 000005",
                FullName = "Смирнова Елена Андреевна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1997, 11, 5),
                Phone = "+79990000005",
                StartDate = new DateTime(2026, 4, 1),
                EndDate = new DateTime(2026, 10, 31)
            },
            new Client
            {
                PassportNumber = "1000 000006",
                FullName = "Попов Дмитрий Олегович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1990, 1, 25),
                Phone = "+79990000006",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 10, 31)
            },
            new Client
            {
                PassportNumber = "1000 000007",
                FullName = "Волкова Мария Игоревна",
                Gender = Gender.Female,
                BirthDate = new DateTime(2001, 6, 18),
                Phone = "+79990000007",
                StartDate = new DateTime(2026, 5, 1),
                EndDate = new DateTime(2026, 12, 15)
            },
            new Client
            {
                PassportNumber = "1000 000008",
                FullName = "Морозов Максим Николаевич",
                Gender = Gender.Male,
                BirthDate = new DateTime(1996, 4, 8),
                Phone = "+79990000008",
                StartDate = new DateTime(2025, 2, 1),
                EndDate = new DateTime(2026, 2, 28)
            },
            new Client
            {
                PassportNumber = "1000 000009",
                FullName = "Фёдорова Ольга Владимировна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1999, 8, 22),
                Phone = "+79990000009",
                StartDate = new DateTime(2026, 6, 1),
                EndDate = new DateTime(2026, 12, 20)
            },
            new Client
            {
                PassportNumber = "1000 000010",
                FullName = "Николаев Артём Дмитриевич",
                Gender = Gender.Male,
                BirthDate = new DateTime(1994, 12, 3),
                Phone = "+79990000010",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 12, 31)
            }
        ];

        Trainers =
        [
            new Trainer
            {
                PassportNumber = "2000 000001",
                FullName = "Алексеев Андрей Сергеевич",
                Gender = Gender.Male,
                BirthDate = new DateTime(1985, 2, 14),
                Specialization = Specializations[0],
                WorkExperience = 8
            },
            new Trainer
            {
                PassportNumber = "2000 000002",
                FullName = "Борисова Наталья Игоревна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1990, 4, 19),
                Specialization = Specializations[3],
                WorkExperience = 4
            },
            new Trainer
            {
                PassportNumber = "2000 000003",
                FullName = "Васильев Дмитрий Олегович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1982, 8, 11),
                Specialization = Specializations[1],
                WorkExperience = 12
            },
            new Trainer
            {
                PassportNumber = "2000 000004",
                FullName = "Громова Ирина Александровна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1988, 6, 23),
                Specialization = Specializations[4],
                WorkExperience = 6
            },
            new Trainer
            {
                PassportNumber = "2000 000005",
                FullName = "Данилов Сергей Владимирович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1987, 10, 5),
                Specialization = Specializations[2],
                WorkExperience = 9
            },
            new Trainer
            {
                PassportNumber = "2000 000006",
                FullName = "Егорова Светлана Павловна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1993, 3, 17),
                Specialization = Specializations[7],
                WorkExperience = 3
            },
            new Trainer
            {
                PassportNumber = "2000 000007",
                FullName = "Жуков Александр Михайлович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1984, 1, 29),
                Specialization = Specializations[6],
                WorkExperience = 10
            },
            new Trainer
            {
                PassportNumber = "2000 000008",
                FullName = "Захарова Екатерина Романовна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1991, 9, 7),
                Specialization = Specializations[5],
                WorkExperience = 7
            },
            new Trainer
            {
                PassportNumber = "2000 000009",
                FullName = "Ильин Роман Евгеньевич",
                Gender = Gender.Male,
                BirthDate = new DateTime(1986, 12, 16),
                Specialization = Specializations[8],
                WorkExperience = 11
            },
            new Trainer
            {
                PassportNumber = "2000 000010",
                FullName = "Крылова Виктория Андреевна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1992, 7, 30),
                Specialization = Specializations[9],
                WorkExperience = 5
            }
        ];

        Trainings =
        [
            new Training
            {
                Id = 1,
                Client = Clients[0],
                Trainer = Trainers[0],
                Hall = Halls[0],
                StartTime = DateTime.Today.AddHours(9),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 2,
                Client = Clients[1],
                Trainer = Trainers[0],
                Hall = Halls[0],
                StartTime = DateTime.Today.AddHours(11),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 3,
                Client = Clients[2],
                Trainer = Trainers[1],
                Hall = Halls[1],
                StartTime = DateTime.Today.AddHours(10),
                DurationMinutes = 60,
                IsTrial = true
            },
            new Training
            {
                Id = 4,
                Client = Clients[3],
                Trainer = Trainers[1],
                Hall = Halls[1],
                StartTime = DateTime.Today.AddHours(12),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 5,
                Client = Clients[4],
                Trainer = Trainers[2],
                Hall = Halls[2],
                StartTime = DateTime.Today.AddHours(9),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 6,
                Client = Clients[5],
                Trainer = Trainers[2],
                Hall = Halls[2],
                StartTime = DateTime.Today.AddHours(11),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 7,
                Client = Clients[6],
                Trainer = Trainers[2],
                Hall = Halls[3],
                StartTime = DateTime.Today.AddHours(13),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 8,
                Client = Clients[7],
                Trainer = Trainers[2],
                Hall = Halls[3],
                StartTime = DateTime.Today.AddHours(15),
                DurationMinutes = 60,
                IsTrial = true
            },
            new Training
            {
                Id = 9,
                Client = Clients[8],
                Trainer = Trainers[3],
                Hall = Halls[4],
                StartTime = DateTime.Today.AddHours(10),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 10,
                Client = Clients[9],
                Trainer = Trainers[3],
                Hall = Halls[4],
                StartTime = DateTime.Today.AddHours(12),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 11,
                Client = Clients[0],
                Trainer = Trainers[6],
                Hall = Halls[5],
                StartTime = DateTime.Today.AddHours(9),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 12,
                Client = Clients[1],
                Trainer = Trainers[6],
                Hall = Halls[5],
                StartTime = DateTime.Today.AddHours(11),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 13,
                Client = Clients[2],
                Trainer = Trainers[6],
                Hall = Halls[6],
                StartTime = DateTime.Today.AddHours(13),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 14,
                Client = Clients[3],
                Trainer = Trainers[8],
                Hall = Halls[7],
                StartTime = DateTime.Today.AddHours(10),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 15,
                Client = Clients[4],
                Trainer = Trainers[8],
                Hall = Halls[7],
                StartTime = DateTime.Today.AddHours(12),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 16,
                Client = Clients[5],
                Trainer = Trainers[8],
                Hall = Halls[8],
                StartTime = DateTime.Today.AddHours(14),
                DurationMinutes = 60,
                IsTrial = true
            },
            new Training
            {
                Id = 17,
                Client = Clients[6],
                Trainer = Trainers[9],
                Hall = Halls[9],
                StartTime = DateTime.Today.AddHours(9),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 18,
                Client = Clients[7],
                Trainer = Trainers[9],
                Hall = Halls[9],
                StartTime = DateTime.Today.AddHours(11),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 19,
                Client = Clients[8],
                Trainer = Trainers[9],
                Hall = Halls[9],
                StartTime = DateTime.Today.AddHours(13),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 20,
                Client = Clients[9],
                Trainer = Trainers[4],
                Hall = Halls[0],
                StartTime = DateTime.Today.AddDays(1).AddHours(10),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 21,
                Client = Clients[0],
                Trainer = Trainers[0],
                Hall = Halls[0],
                StartTime = DateTime.Today.AddDays(2).AddHours(10),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 22,
                Client = Clients[1],
                Trainer = Trainers[0],
                Hall = Halls[0],
                StartTime = DateTime.Today.AddDays(3).AddHours(10),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 23,
                Client = Clients[2],
                Trainer = Trainers[2],
                Hall = Halls[2],
                StartTime = DateTime.Today.AddDays(2).AddHours(10),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 24,
                Client = Clients[3],
                Trainer = Trainers[2],
                Hall = Halls[2],
                StartTime = DateTime.Today.AddDays(3).AddHours(10),
                DurationMinutes = 60,
                IsTrial = false
            },
            new Training
            {
                Id = 25,
                Client = Clients[4],
                Trainer = Trainers[6],
                Hall = Halls[6],
                StartTime = DateTime.Today.AddDays(2).AddHours(15),
                DurationMinutes = 60,
                IsTrial = false
            }
        ];
    }
}