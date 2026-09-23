namespace FitnessClub.Tests;

/// <summary>
/// Тесты запросов к данным фитнес-клуба.
/// </summary>
public class QueriesTest : IClassFixture<QueriesTestFixture>
{
    private readonly QueriesTestFixture _fixture;

    /// <summary>
    /// Создаёт экземпляр класса тестов.
    /// </summary>
    /// <param name="fixture">Набор тестовых данных.</param>
    public QueriesTest(QueriesTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверяет получение тренеров со стажем не менее пяти лет.
    /// </summary>
    [Fact]
    public void GetExperiencedTrainers_ShouldReturnTrainersWithExperienceAtLeastFiveYears()
    {
        var trainers = _fixture.Trainers
            .Where(trainer => trainer.WorkExperience >= 5)
            .OrderBy(trainer => trainer.FullName)
            .ToList();

        Assert.NotEmpty(trainers);

        Assert.All(
            trainers,
            trainer => Assert.True(
                trainer.WorkExperience >= 5));
    }

    /// <summary>
    /// Проверяет доступность выбранного зала в текущий момент.
    /// </summary>
    [Fact]
    public void IsHallAvailable_ShouldReturnCorrectAvailability()
    {
        var hall = _fixture.Halls.First();

        var currentDateTime = DateTime.Now;

        var isAvailable = !_fixture.Trainings
            .Where(training => training.Hall.Id == hall.Id)
            .Any(training =>
                currentDateTime >= training.StartTime &&
                currentDateTime <
                training.StartTime.AddMinutes(
                    training.DurationMinutes));

        Assert.True(isAvailable);
    }

    /// <summary>
    /// Проверяет получение клиентов с просроченным абонементом.
    /// </summary>
    [Fact]
    public void GetClientsWithExpiredSubscriptions_ShouldReturnSortedClients()
    {
        var today = DateTime.Today;

        var clients = _fixture.Clients
            .Where(client => client.EndDate < today)
            .OrderBy(client => client.FullName)
            .ToList();

        Assert.NotEmpty(clients);

        Assert.All(
            clients,
            client => Assert.True(
                client.EndDate < today));

        var sortedNames = clients
            .Select(client => client.FullName)
            .OrderBy(name => name)
            .ToList();

        Assert.Equal(
            sortedNames,
            clients.Select(client => client.FullName).ToList());
    }

    /// <summary>
    /// Проверяет получение занятий за текущий месяц в выбранном зале.
    /// </summary>
    [Fact]
    public void GetTrainingsForCurrentMonthAndSelectedHall_ShouldReturnCorrectTrainings()
    {
        var selectedHall = _fixture.Halls.First();

        var today = DateTime.Today;

        var monthStart = new DateTime(
            today.Year,
            today.Month,
            1);

        var nextMonthStart = monthStart.AddMonths(1);

        var trainings = _fixture.Trainings
            .Where(training =>
                training.Hall.Id == selectedHall.Id &&
                training.StartTime >= monthStart &&
                training.StartTime < nextMonthStart)
            .OrderBy(training => training.StartTime)
            .ToList();

        Assert.NotEmpty(trainings);

        Assert.All(
            trainings,
            training =>
            {
                Assert.Equal(selectedHall.Id, training.Hall.Id);
                Assert.True(training.StartTime >= monthStart);
                Assert.True(training.StartTime < nextMonthStart);
            });
    }

    /// <summary>
    /// Проверяет получение пяти наиболее популярных тренеров.
    /// </summary>
    [Fact]
    public void GetTopFivePopularTrainers_ShouldReturnFiveTrainers()
    {
        var topTrainers = _fixture.Trainers
            .Select(trainer => new
            {
                Trainer = trainer,
                TrainingCount = _fixture.Trainings.Count(
                    training => training.Trainer.PassportNumber ==
                                 trainer.PassportNumber)
            })
            .OrderByDescending(item => item.TrainingCount)
            .ThenBy(item => item.Trainer.FullName)
            .Take(5)
            .ToList();

        Assert.Equal(5, topTrainers.Count);

        Assert.All(
            topTrainers,
            item => Assert.NotNull(item.Trainer));

        for (var index = 1; index < topTrainers.Count; index++)
        {
            Assert.True(
                topTrainers[index - 1].TrainingCount >=
                topTrainers[index].TrainingCount);
        }
    }
}