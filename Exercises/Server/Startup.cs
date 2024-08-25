using Server.Business;

namespace Server;
public static class Startup
{
    public static void AddExerciseServices(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddScoped<ExerciseManager>();
        services.AddScoped<ExerciseSetManager>();
    }
}