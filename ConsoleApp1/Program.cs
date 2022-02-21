using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

const string connectionString = @"Data Source=data.db;";

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => services
        .AddDbContextFactory<AppDbContext>(options => options.UseSqlite(connectionString))
        .AddScoped<IDatabaseTest, DatabaseTest>()
    ).Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;
var dbContext = provider.GetRequiredService<AppDbContext>();
dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();

DoDbContextTest(provider);

await host.RunAsync();

static void DoDbContextTest(IServiceProvider provider)
{
    var tester = provider.GetRequiredService<IDatabaseTest>();
    tester.DoTest();
}
