using Microsoft.EntityFrameworkCore;
using TalentTrek.Api.Data;
using TalentTrek.Api.Services;
using TalentTrek.Api.Services.Interfaces;
using FluentValidation;
using TalentTrek.Api.Validators;
using FluentValidation.AspNetCore;
using TalentTrek.Api.Filters;
using TalentTrek.Api.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => {
    // add validation filter to all controllers
    options.Filters.Add<ValidationFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAppServices();
builder.Services.AddRepositories();
builder.Services.AddAppConfigs(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);

// add Serilog as the default logger
builder.Logging.ClearProviders();
builder.Host.AddLogger();

// add validators for the dependency injection
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CandidateSignUpValidator>();

// Add healthcheck service
builder.Services.AddHealthChecks();


var app = builder.Build();
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

