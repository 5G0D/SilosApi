using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SilosApi.DbContexts;
using SilosApi.Dto;
using SilosApi.Enums;
using SilosApi.Options;
using SilosApi.Repositories;
using SilosApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Silos API", Version = "v1" });
    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<SilosDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SilosDB")));

builder.Services.AddAutoMapper(_ => { }, Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ISilosRepository, SilosRepository>();
builder.Services.AddScoped<ISilosService, SilosService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => 
        policy.RequireRole(UserRoleEnum.Admin.ToString()));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtOption = builder.Configuration.GetSection("Jwt").Get<JwtOption>() ??
                        throw new NullReferenceException("JWT configuration section not found");
        
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOption.Issuer,
            ValidAudience = jwtOption.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOption.Key))
        };
    });

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<SilosDbContext>();

    if (context != null)
    {
        //context.Database.EnsureDeleted();
        await context.Database.MigrateAsync();
        
        var authService = serviceScope.ServiceProvider.GetRequiredService<IAuthService>();
        
        var defaultUsers = builder.Configuration.GetSection("DefaultUsers").Get<List<UserOption>>() ?? [];

        foreach (var user in defaultUsers)
        {
            var usersExists = await context.Users.AnyAsync(x => x.Username == user.Username);
            
            if (!usersExists)
            {
                await authService.Register(
                    new LoginDto
                    {
                        Username = user.Username, 
                        Password = user.Password
                    }, 
                    user.UserRoleEnum);
            }
        }
    }
}

app.UseCors("AllowAll");

app.MapControllers();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
