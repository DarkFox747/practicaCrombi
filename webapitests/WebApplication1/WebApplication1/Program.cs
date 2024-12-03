using WebApplication1.Data;
using WebApplication1.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

var logFilePath = Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory,
    "Logs",
    "appi-errors.log");
Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new FileLogger(logFilePath));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<BibliotecaDbContext>();
builder.Services.AddScoped<IBibliotecaService, BibliotecaService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<SqlConnection>(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ErrorLoggingMiddleware>();
app.MapControllers();
app.Run();