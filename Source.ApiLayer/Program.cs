using Microsoft.EntityFrameworkCore;
using Source.ApiLayer.Database;
using Source.ApiLayer.Interface;
using Source.ApiLayer.Service;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().SetBasePath(System.Environment.CurrentDirectory).AddJsonFile("appsettings.json").Build();
string env = config.GetSection("Env").Value;
var configuration = new ConfigurationBuilder().SetBasePath(System.Environment.CurrentDirectory)
                           .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true)
                           .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SoruceContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitofWorkRepo>();
builder.Services.AddScoped<ISource, ClsSourceSvc>();

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
