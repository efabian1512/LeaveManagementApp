using LeaveManagement.Application.Services.Email;
using LeaveManagement.Application.Services.LeaveAllocations;
using LeaveManagement.Application.Services.LeaveRequests;
using LeaveManagement.Application.Services.LeaveTypes;
using LeaveManagement.Application.Services.Periods;
using LeaveManagement.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ILeaveTypesService, LeaveTypesService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPeriodsService, PeriodsService>();
            services.AddScoped<ILeaveAllocationsService, LeaveAllocationsService>();
            services.AddScoped<IleaveRequestsService, LeaveRequestsService>();
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
