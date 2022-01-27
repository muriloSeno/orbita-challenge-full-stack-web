using GroupA.Application.ApplicationServices;
using GroupA.Application.AutoMapper;
using GroupA.Application.Interfaces.ApplicationServices;
using GroupA.Application.Interfaces.Services;
using GroupA.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GroupA.Application
{
    public static class DependencyInjectionApp
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection service)
        {
            service.RegisterAutoMapper();
            service.AddScoped<IAlunoService, AlunoService>();
            service.AddScoped<IAlunoApplicationService, AlunoApplicationService>();
            return service;
        }
    }
}
