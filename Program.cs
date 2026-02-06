using Microsoft.EntityFrameworkCore;
using SaleMasterApi.Data;

// DDD
using SaleMasterApi.Interfaces;
using SaleMasterApi.Repositories;
using SaleMasterApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Mostra logs do ASP.NET no console (ajuda muito no debug)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// --------------------
// Banco (EF + MySQL)
// --------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("❌ ERRO: ConnectionString 'DefaultConnection' não encontrada no appsettings.json.");
    // Encerra com erro explícito (melhor do que fechar “silencioso”)
    throw new InvalidOperationException("ConnectionString 'DefaultConnection' não encontrada.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// --------------------
// Controllers + Swagger
// --------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Registra Swagger (pode dar erro se pacote estiver quebrado, então protegemos)
try
{
    builder.Services.AddSwaggerGen();
    Console.WriteLine("✅ SwaggerGen registrado.");
}
catch (Exception ex)
{
    Console.WriteLine("⚠️ SwaggerGen NÃO foi registrado (seguindo sem Swagger).");
    Console.WriteLine(ex.ToString());
}

// --------------------
// DDD - Injeção de Dependência
// (se houver erro em alguma classe, ele vai aparecer aqui)
// --------------------
try
{
    builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
    builder.Services.AddScoped<ProdutoService>();
    Console.WriteLine("✅ DI (Repository/Service) registrado.");
}
catch (Exception ex)
{
    Console.WriteLine("❌ Erro registrando DI (Repository/Service).");
    Console.WriteLine(ex.ToString());
    throw;
}

var app = builder.Build();

Console.WriteLine($">>> ENV: {app.Environment.EnvironmentName}");
Console.WriteLine(">>> API INICIANDO - depois do builder.Build()");

// Endpoint de teste rápido
app.MapGet("/ping", () => "pong");

// Swagger só em Development (padrão)
if (app.Environment.IsDevelopment())
{
    try
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        Console.WriteLine("✅ Swagger habilitado (Development).");
    }
    catch (Exception ex)
    {
        Console.WriteLine("⚠️ Swagger NÃO foi habilitado (seguindo sem Swagger).");
        Console.WriteLine(ex.ToString());
    }
}

app.UseAuthorization();
app.MapControllers();

Console.WriteLine(">>> API INICIANDO - antes do app.Run()");
app.Run();
