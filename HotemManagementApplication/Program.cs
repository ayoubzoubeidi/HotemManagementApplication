using HotelManagementDataLibrary;
using Serilog;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();

Serilog.ILogger logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(configuration);
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
