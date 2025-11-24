//using StudelSettingsAPI.Data;
using Microsoft.EntityFrameworkCore;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure DbContext with SQL Server
builder.Services.AddDbContext<strudelSettingsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("strudelSettingsDbContext")
        ?? throw new InvalidOperationException("Connection string 'strudelSettingsDbContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS for all origins, methods, and headers
app.UseCors(b => {
    b.AllowAnyMethod();
    b.AllowAnyOrigin();
    b.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();