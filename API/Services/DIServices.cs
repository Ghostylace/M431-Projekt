using API.Services.Abstract;

namespace API.Services;

public static class DIServices
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IGradeAdjustmentService, GradeAdjustmentService>();
        services.AddScoped<IProrectorService, ProrectorService>();
        services.AddScoped<IGradeAdjustmentService, GradeAdjustmentService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IModuleService, ModuleService>();
        services.AddScoped<IProrectorService, ProrectorService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
