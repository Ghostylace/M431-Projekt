using API.Services;
using API.Services.Abstract;
using Supabase;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddServiceLayer();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IGradeAdjustmentService, GradeAdjustmentService>();
        builder.Services.AddScoped<ITeacherService, TeacherService>();
        builder.Services.AddScoped<IStudentService, StudentService>();
        builder.Services.AddScoped<IModuleService, ModuleService>();
        builder.Services.AddScoped<IProrectorService, ProrectorService>();
        builder.Services.AddScoped<IAuthService, AuthService>();




        // CORS konfigurieren
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", policy =>
            {
                policy
                    .WithOrigins(
                        "https://localhost:7038",
                        "http://localhost:5000",
                        "https://localhost:7113")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        // Supabase Client registrieren
        builder.Services.AddSingleton(provider =>
        {
            return new Client(
                builder.Configuration["Supabase:Url"],
                builder.Configuration["Supabase:AnonKey"],
                new SupabaseOptions
                {
                    AutoConnectRealtime = true
                }
            );
        });

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("AllowSpecificOrigin");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
