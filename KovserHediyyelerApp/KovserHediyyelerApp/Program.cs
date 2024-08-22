using FluentValidation;
using FluentValidation.AspNetCore;
using KovserHediyyeler.Core.Repositories.Abstractions.Categories;
using KovserHediyyeler.Data.Context;
using KovserHediyyeler.Data.Repositories.Concretes.Categories;
using KovserHediyyeler.Service.Profiles;
using KovserHediyyeler.Service.Services.Abstractions;
using KovserHediyyeler.Service.Services.Concretes;
using KovserHediyyeler.Service.Validations.Categories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Project.App
builder.Services.AddControllers();
//Project.Data
builder.Services.AddDbContext<KovserHediyyelerDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
//Project.Service
builder.Services.AddValidatorsFromAssemblyContaining<CategoryPostDtoValidation>().AddFluentValidationClientsideAdapters();
builder.Services.AddAutoMapper(typeof(CategoryMap));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Repositories
builder.Services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
builder.Services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
//Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
//Cors
builder.Services.AddCors(o => o.AddPolicy("Kovser", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Kovser");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
