using Microsoft.EntityFrameworkCore;
using TalentTrek.Api.Data;
using TalentTrek.Api.Services;
using TalentTrek.Api.Services.Interfaces;
using FluentValidation;
using TalentTrek.Api.Validators;
using FluentValidation.AspNetCore;
using TalentTrek.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => {
    // add validation filter to all controllers
    options.Filters.Add<ValidationFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// add validators for the dependency injection
builder.Services.AddValidatorsFromAssemblyContaining<CandidateRegistrationValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IAuthService, AuthService>();

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

