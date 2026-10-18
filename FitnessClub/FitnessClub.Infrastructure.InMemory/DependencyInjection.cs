using FitnessClub.Domain.Interfaces;
using FitnessClub.Infrastructure.InMemory.Data;
using FitnessClub.Infrastructure.InMemory.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.Infrastructure.InMemory;

/// <summary>
/// Методы регистрации сервисов инфраструктуры хранения в памяти.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Регистрирует общее хранилище и репозитории фитнес-клуба.
    /// </summary>
    /// <param name="services">Коллекция сервисов приложения.</param>
    /// <returns>Коллекция зарегистрированных сервисов.</returns>
    public static IServiceCollection AddInMemoryInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<FitnessClubDataStore>(_ =>
        {
            var store = new FitnessClubDataStore();
            FitnessClubDataSeeder.Seed(store);
            return store;
        });

        services.AddSingleton<IClientRepository, ClientRepository>();
        services.AddSingleton<ITrainerRepository, TrainerRepository>();
        services.AddSingleton<ISpecializationRepository, SpecializationRepository>();
        services.AddSingleton<IHallRepository, HallRepository>();
        services.AddSingleton<ITrainingRepository, TrainingRepository>();

        return services;
    }
}