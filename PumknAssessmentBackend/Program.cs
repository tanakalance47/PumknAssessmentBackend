using PumknAssessmentBackend.Services.Implementation;
using PumknAssessmentBackend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add HTTP Client
builder.Services.AddHttpClient();

//Dependency Injection
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IExternalBeerService, ExternalBeerService>();

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
