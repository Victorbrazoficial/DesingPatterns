using DesingPatterns.Application.ChainOfResponsability.Calculador;
using DesingPatterns.Application.ChainOfResponsability.Calculador.Interface;
using DesingPatterns.Application.ChainOfResponsability.Repositories;
using DesingPatterns.Application.ChainOfResponsability.UseCase;
using DesingPatterns.Application.ChainOfResponsability.UseCase.Interface;
using DesingPatterns.Application.Strategy.Calculador;
using DesingPatterns.Application.Strategy.Calculador.Interface;
using DesingPatterns.Application.Strategy.Repositories;
using DesingPatterns.Application.Strategy.UseCase.Imposto;
using DesingPatterns.Application.Strategy.UseCase.Imposto.Interface;
using DesingPatterns.Infrastructure.Repositories.ChainOfResponsability;
using DesingPatterns.Infrastructure.Strategy.Repositories.Imposto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IObterImpostoDeduzidoUseCase, ObterImpostoDeduzidoUseCase>();
builder.Services.AddScoped<ITaxaImpostoRepository, TaxaImpostoRepository>();
builder.Services.AddScoped<ICalculador, Calculador>();
builder.Services.AddSingleton<IDescontoUseCase, DescontoUseCase>();
builder.Services.AddSingleton<ITaxaDescontoRepository, TaxaDescontoRepository>();
builder.Services.AddSingleton<ICalculadorDescontos, CalculadorDescontos>();


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
