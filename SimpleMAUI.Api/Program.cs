using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleMAUI.BLL.Helper;
using System.Reflection;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddDbContext<SimpleMAUIDbContext>(options =>
        {
            var connectionString = Environment.GetEnvironmentVariable("DBConnection");
            options.UseNpgsql(connectionString);
        });
        services.AddHttpContextAccessor();
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

    })
    .Build();

await host.RunAsync();
