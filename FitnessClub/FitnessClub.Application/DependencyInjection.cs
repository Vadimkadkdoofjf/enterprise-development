using FitnessClub.Application.Services.Clients;
using FitnessClub.Application.Services.Trainers;
using FitnessClub.Contracts.Services.Clients;
using FitnessClub.Contracts.Services.Trainers;
using Microsoft.Extensions.DependencyInjection;
using FitnessClub.Application.Services.Specializations;
using FitnessClub.Contracts.Services.Specializations;
using FitnessClub.Application.Services.Halls;
using FitnessClub.Contracts.Services.Halls;
using FitnessClub.Application.Services.Trainings;
using FitnessClub.Contracts.Services.Trainings;
using FitnessClub.Application.Services.Analytics;
using FitnessClub.Contracts.Services.Analytics;

namespace FitnessClub.Application;

/// <summary>
/// Регистрация зависимостей уровня Application.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Регистрирует сервисы приложения.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <returns>Обновлённая коллекция сервисов.</returns>
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ITrainerService, TrainerService>();
        services.AddScoped<ISpecializationService, SpecializationService>();
        services.AddScoped<IHallService, HallService>();
        services.AddScoped<ITrainingService, TrainingService>();
        services.AddScoped<IAnalyticsService, AnalyticsService>();
        return services;
    }
}