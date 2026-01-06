using API.Services.Abstract;

namespace API.Services;

public static class DIServices
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IGradeAdjustmentService, GradeAdjustmentService>();
        services.AddScoped<IProrectorService, ProrectorService>();

        return services;
    }
}
