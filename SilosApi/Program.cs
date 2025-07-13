using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SilosApi.DbContexts;
using SilosApi.Repositories;
using SilosApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Silos API", Version = "v1" });
});

builder.Services.AddDbContext<SilosDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PGDatabase")));

builder.Services.AddAutoMapper(_ => { }, Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ISilosRepository, SilosRepository>();
builder.Services.AddScoped<ISilosService, SilosService>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<SilosDbContext>();

    if (context != null)
    {
        //context.Database.EnsureDeleted();
        await context.Database.MigrateAsync();
    }
}

app.MapControllers();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
