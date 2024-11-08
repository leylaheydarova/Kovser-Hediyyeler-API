
using Kovser.Hediyyeler.App.RegistrationServices;
using KovserHedieyyeler.Application.ServiceRegistrations;
using KovserHedieyyeler.Infrastructure.Services.StorageServices.LocalStorage;
using KovserHediyyeler.Infrastructure.RegistrationServices;
using KovserHediyyeler.Persistence.RegistrationServices;
using Serilog;
using Store.App.ServiceRegistrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//AppRegistrationServices.ConfigureLogging(builder.Configuration);
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
    .AppServiceRegistrationServices(builder.Configuration)
    .RegisterSwaggerServices();

//builder.Services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/admin_v1/swagger.json", "My API - V1");
        c.SwaggerEndpoint("/swagger/client_v1/swagger.json", "My API - V2");
    });
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

