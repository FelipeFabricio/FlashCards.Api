using FlashCards.Api.Configurations;
using FlashCards.Business.Validators;
using FlashCards.Data.Context;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

SerilogExtension.AddSerilogApi(builder.Configuration);
builder.Host.UseSerilog(Log.Logger); //Registra Serilog como Log padrão

builder.Services.AddControllers().AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<DeckValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ResolveDependencies();
builder.Services.AddDbContext<FlashCardContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
