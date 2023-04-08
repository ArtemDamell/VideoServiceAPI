using Microsoft.Extensions.DependencyInjection;
using TaskManagementApp.Infrastructure.Repositories;
using VideoService.Services.Interfaces;

namespace TaskManagementApp.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the infrastructure services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryOfWork, CategoryOfWork>();

            return services;
        }
    }
}
