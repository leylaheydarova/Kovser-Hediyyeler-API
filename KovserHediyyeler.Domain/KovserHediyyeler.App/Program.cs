using KovserHedieyyeler.Application.ServiceRegistrations;
using KovserHediyyeler.App.ServiceRegistrations;
using KovserHediyyeler.Infrastructure.ServiceRegistrations;
using KovserHediyyeler.Persistence.ServiceRegistrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .RegisterDataServices(builder.Configuration)
    .RegisterInfrastructureServices()
    .AppServiceRegistrationServices(builder.Configuration)
    .RegisterLoginServices(builder.Configuration)
    .RegisterApplicationServices();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

        // Bütün controllerlərin endpointlərini qapalı saxlamaq üçün
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}
app.UseStaticFiles();

app.UseCors("KovserHediyyeler");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
