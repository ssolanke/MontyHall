
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MontyHall.Service.Repositories;

namespace MontyHall.Service
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Interfaces.IGameRepository, GameRepository>();
            services.Add(new ServiceDescriptor(typeof(ILogger), null));
        }
    }
}
