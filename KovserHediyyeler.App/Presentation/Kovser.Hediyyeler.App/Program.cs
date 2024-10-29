
using Kovser.Hediyyeler.App.RegistrationServices;
using KovserHedieyyeler.Application.ServiceRegistrations;
using KovserHedieyyeler.Infrastructure.Services.StorageServices.LocalStorage;
using KovserHediyyeler.Infrastructure.RegistrationServices;
using KovserHediyyeler.Persistence.RegistrationServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
AppRegistrationServices.ConfigureLogging(builder.Configuration);
builder.Host.UseSerilog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterLibrariesServices();
builder.Services.AddSwaggerGen();
//builder.Host.UserSerilog();
builder.Services
    .RegisterDataServices(builder.Configuration)
    .RegisterStorageServices()
    .AddStorage<LocalStorageService>()
    .RegisterLoginServices(builder.Configuration)
    .RegisterInfrastructureServices()
    .AppServiceRegistrationServices(builder.Configuration);

//builder.Services

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

//app.ConfigureExceptionHandler();
    app.UseSerilogRequestLogging();//ozunden sonrakilar loglanir ancaq.

    app.UseCors("KovserHediyyeler");

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

