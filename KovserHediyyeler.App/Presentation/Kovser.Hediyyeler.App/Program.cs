using Kovser.Hediyyeler.App.RegistrationServices;
using KovserHedieyyeler.Infrastructure.Services.StorageServices.LocalStorage;
using KovserHediyyeler.Infrastructure.RegistrationServices;
using KovserHediyyeler.Persistence.RegistrationServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterMediaTrServices();
builder.Services
    .RegisterDataServices(builder.Configuration)
    .RegisterStorageServices()
    .AddStorage<LocalStorageService>();



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

