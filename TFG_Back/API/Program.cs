using RecetasRedondas.Business;
using RecetasRedondas.Models;
using RecetasRedondas.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Determinar si está ejecutándose dentro de Docker
var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var keyString = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
var connectionString = builder.Configuration.GetConnectionString(keyString);

// Añadir servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<RecetasRedondasAppContext>(options =>
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Número máximo de intentos
            maxRetryDelay: TimeSpan.FromSeconds(30), // Tiempo máximo de espera entre intentos
            errorNumbersToAdd: null); // Errores específicos para reintentos, null para los predeterminados
    }));

// Registrar repositorios específicos
builder.Services.AddScoped<IRecetaRepository, RecetaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IIngredienteRepository, IngredienteRepository>();
builder.Services.AddScoped<IRecetaIngredienteRepository, RecetaIngredienteRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMenuSemanalRepository, MenuSemanalRepository>();
builder.Services.AddScoped<IMenuSemanalRecetaRepository, MenuSemanalRecetaRepository>();

// Registrar servicios
builder.Services.AddScoped<IRecetaService, RecetaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IIngredienteService, IngredienteService>();
builder.Services.AddScoped<IRecetaIngredienteService, RecetaIngredienteService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMenuSemanalService, MenuSemanalService>();
builder.Services.AddScoped<IMenuSemanalRecetaService, MenuSemanalRecetaService>();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:9001")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configurar el pipeline de solicitudes HTTP.
var app = builder.Build();

// Habilitar middleware para servir Swagger como un endpoint JSON.
app.UseSwagger();
app.UseSwaggerUI();

// Usar la política de CORS
app.UseCors("MyCorsPolicy");

// Descomentar la siguiente línea si implementas redirección HTTPS.
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
