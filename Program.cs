using worknet_api.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using worknet_api.Helpers.Services;
using worknet_api.Helpers;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
// Add services to the container.

builder.Services.AddDbContext<ApiContext>(options => 
    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers()
       .AddNewtonsoftJson(options =>
       {
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
       });
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<AuthService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<GenerateToken>();

var app = builder.Build();

// Configure the HTTP request pipeline.
 app.UseSwagger();
 app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

app.Run();
