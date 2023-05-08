using trailblazers_api.Context;
using trailblazers_api.Repositories.Builds;
using trailblazers_api.Repositories.Eidolons;
using trailblazers_api.Repositories.Elements;
using trailblazers_api.Services.Elements;

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

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<DapperContext>();

    services.AddScoped<IElementService, ElementService>();

    services.AddScoped<IBuildRepository, BuildRepository>();
    services.AddScoped<IEidolonRepository, EidolonRepository>();
    services.AddScoped<IElementRepository, ElementRepository>();
}