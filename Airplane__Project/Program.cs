using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Airplane_Project_2023.Interfaces;
using Airplane_Project_2023.Repositories;
using LogicAndConnectionToDb.Interfaces;
using Terminals_Sim.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});


builder.Services.AddDbContext<AirplaneDB>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ITerminalIRepository, TerminalRepository>();


builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
    build.WithOrigins("*");
    build.AllowAnyMethod();
    build.AllowAnyHeader();
}));

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*");
    build.AllowAnyMethod();
    build.AllowAnyHeader();
}));

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();