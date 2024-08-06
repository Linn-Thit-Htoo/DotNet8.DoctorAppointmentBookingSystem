using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Patient;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.DoctorAppointmentBookingSystem.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContextService(builder)
                .AddCustomServices();
            return services;
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            return services;
        }
    }
}
