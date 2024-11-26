using WebApplication1.Data;
using WebApplication1.Services;

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