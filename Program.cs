using System.Text.Json.Serialization;
using NETCore.DTOs;
using NETCore.Models;
using NETCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the services for dependency injection
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IOrderProcessingService, OrderProcessingService>();
builder.Services.AddScoped<IEmailSenderService, FakeEmailSenderService>();
builder.Services.AddSingleton<IChatGPTService, FakeChatGPTService>();

builder.Services.AddSingleton<ICounterService, RequestCounterService>();
//
builder.Services.AddTransient<IDemoService, DemoService>();
builder.Services.AddSingleton<ICourseService, FakeCourseService>();
//builder.Services.AddSingleton<ICrudService<Student, StudentDTO>, FakeStudentService>();
builder.Services.AddSingleton<ICrudService<Student, StudentDTO>, FakeCrudService<Student, StudentDTO>>();
//Tell DI about the setting setion
builder.Services.Configure<CourseSetting>(builder.Configuration.GetSection("Course:Batch"));

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
