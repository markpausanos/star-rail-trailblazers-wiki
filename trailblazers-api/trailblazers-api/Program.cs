using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using trailblazers_api.Context;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Builds;
using trailblazers_api.Repositories.Eidolons;
using trailblazers_api.Repositories.Elements;
using trailblazers_api.Repositories.Lightcones;
using trailblazers_api.Repositories.Ornaments;
using trailblazers_api.Repositories.Paths;
using trailblazers_api.Repositories.Posts;
using trailblazers_api.Repositories.Relics;
using trailblazers_api.Repositories.Skills;
using trailblazers_api.Repositories.Teams;
using trailblazers_api.Repositories.Traces;
using trailblazers_api.Repositories.Trailblazers;
using trailblazers_api.Repositories.Users;
using trailblazers_api.Services.Builds;
using trailblazers_api.Services.Eidolons;
using trailblazers_api.Services.Elements;
using trailblazers_api.Services.Lightcones;
using trailblazers_api.Services.Ornaments;
using trailblazers_api.Services.Paths;
using trailblazers_api.Services.Relics;
using trailblazers_api.Services.Skills;
using trailblazers_api.Services.Trailblazers;
using trailblazers_api.Services.Users;
using trailblazers_api.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
    services.AddSingleton(cfg => cfg.GetRequiredService<IOptions<JwtSettings>>().Value);
    var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key!))
            };
        });

    services.AddTransient<DapperContext>();

    services.AddScoped<IElementService, ElementService>();
    services.AddScoped<IBuildService, BuildService>();
    services.AddScoped<IEidolonService, EidolonService>();
    services.AddScoped<ILightconeService, LightconeService>();
    services.AddScoped<IOrnamentService, OrnamentService>();
    services.AddScoped<IPathSRService, PathSRService>();
    services.AddScoped<IRelicService, RelicService>();
    services.AddScoped<ISkillService, SkillService>();
    services.AddScoped<ITrailblazerService, TrailblazerService>();
    services.AddScoped<IUserService, UserService>();

    services.AddScoped<IBuildRepository, BuildRepository>();
    services.AddScoped<IEidolonRepository, EidolonRepository>();
    services.AddScoped<IElementRepository, ElementRepository>();
    services.AddScoped<ILightconeRepository, LightconeRepository>();
    services.AddScoped<IOrnamentRepository, OrnamentRepository>();
    services.AddScoped<IPathSRRepository, PathSRRepository>();
    services.AddScoped<IPostRepository, PostRepository>();
    services.AddScoped<IRelicRepository, RelicRepository>();
    services.AddScoped<ISkillRepository, SkillRepository>();
    services.AddScoped<ITeamRepository, TeamRepository>();
    services.AddScoped<ITraceRepository, TraceRepository>();
    services.AddScoped<ITrailblazersRepository, TrailblazerRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
}
