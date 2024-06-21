using FinalProject.DTO;
using FinalProject.Interfaces;
using FinalProject.Store;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.Configure<LandmarkStoreDatabaseSettings>(
//    builder.Configuration.GetSection(nameof(LandmarkStoreDatabaseSettings)));
//builder.Services.AddSingleton<MyLandmarkStoreDatabaseSettings>(
//    sp => sp.GetRequiredService<IOptions<LandmarkStoreDatabaseSettings>>().Value);
var a = builder.Configuration.GetValue<string>("LandmarkStoreDatabaseSettings:ConnectionString");
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("LandmarkStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IMainProsses, MainProcces>();
builder.Services.AddScoped<IGraph,Graph>();
builder.Services.AddScoped<IDijkstra, Dijkstra>();
builder.Services.AddScoped<IMat,Mat>();
builder.Services.AddScoped<IAlgorithmFunction, AlgorithmFunction>();
builder.Services.AddScoped<ILandmarkFunction, LandmarkFunction>();
builder.Services.AddScoped<IRoomFunction, RoomFunction>();
builder.Services.AddScoped<IClassFunction, ClassFunction>();
builder.Services.AddScoped<ICorridorFunction, CorridorFunction>();
builder.Services.AddScoped<IPsrFunction, PsrFunction>();

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

app.Run();
