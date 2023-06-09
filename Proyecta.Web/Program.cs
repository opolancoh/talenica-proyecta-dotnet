using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Proyecta.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigurePersistenceServices();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureControllers();
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ConfigureExceptionHandler(app.Logger);

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseApiVersioning();

// app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// app.MigrateDatabase<AppDbContext>();

app.Run();

// For testing purposes
public partial class Program
{
}