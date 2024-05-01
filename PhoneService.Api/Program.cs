using PhoneService.Api.Services;
using PhoneService.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PhoneServiceWorck>();
builder.Services.AddPhoneServiceCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
//todo убрать свагер перед сдачей проекта

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
