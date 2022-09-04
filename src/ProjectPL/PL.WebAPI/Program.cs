using Core.CrossCuttingConcerns.Exceptions;
using PL.Application;
using PL.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Services from the project layers
builder.Services.AddApplicationServices();
//builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddInfrastructureServices();
//builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//to test custom exceptions in development enviroment
bool customExceptionsInDevelopment = false;
if (customExceptionsInDevelopment || app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
