using System.Text.Json.Serialization;
using HackathonEquipe6.Application.ICNPJBizPersistance;
using HackathonEquipe6.Application.Services;
using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Repositories;
using HackathonEquipe6.Infrastructure.CNPJBizPerisistent;
using HackathonEquipe6.Infrastructure.GoogleMapsPersistent;
using HackathonEquipe6.Infrastructure.Persistance;
using HackathonEquipe6.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ReWindDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IParkRepository, ParkRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IWasteRepository, WasteRepository>();

builder.Services.AddHttpClient<IGoogleMapsService, GoogleMapsService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IWasteService, WasteService>();
builder.Services.AddScoped<IParkService, ParkService>();

builder.Services.AddHttpClient<ICNPJBizPersistance, CNPJBizPersistent>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();