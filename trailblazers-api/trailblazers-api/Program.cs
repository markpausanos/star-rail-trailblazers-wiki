using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using trailblazers_api.Context;
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
using trailblazers_api.Services.Elements;
using trailblazers_api.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
ConfigureServices(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseAuthentication();
app.Run();

void ConfigureServices(IServiceCollection services)
{
    var configuration = builder.Configuration;
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