using GroupA.Application.Interfaces.Repositories;
using GroupA.Infrastructure.Data;
using GroupA.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Infrastructure
{
    public static class Injection
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    options => {
                        options.MigrationsAssembly(typeof(SqlDbContext).Assembly.FullName);
                        options.EnableRetryOnFailure();
                    });
            });
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            return services;
        }
    }
}
