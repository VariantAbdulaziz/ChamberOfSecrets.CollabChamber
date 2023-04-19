using ChamberOfSecrets.CollabChamber.Application;
using ChamberOfSecrets.CollabChamber.Infrastructure;
using ChamberOfSecrets.CollabChamber.Infrastructure.RPC;
using ChamberOfSecrets.CollabChamber.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CollabHub>("api/v1/collabhub");
    endpoints.MapHub<CollabHub>("api/v1/meetinghub");
});

app.UseCors();

app.Run();
