using OutSourcePro.Core.AutoMapperConfig;
using OutSourcePro.Core.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("local"));
});

builder.Services.AddAutoMapper(typeof(AutoMapperConfigProfile));

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
