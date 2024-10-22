using RecetasRedondas.Business;
using RecetasRedondas.Data;
using RecetasRedondas.Models;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        // Obteniendo los valores de configuración
        var validIssuer = builder.Configuration["JWT:ValidIssuer"];
        var validAudience = builder.Configuration["JWT:ValidAudience"];
        var secret = builder.Configuration["JWT:SecretKey"];

        // Verifica si los valores son nulos o vacíos
        if (string.IsNullOrEmpty(validIssuer) || string.IsNullOrEmpty(validAudience) || string.IsNullOrEmpty(secret))
        {
            throw new InvalidOperationException("JWT configuration is missing or invalid.");
        }

        // Configuración de los parámetros de validación de tokens
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret))
        };
    });

// Determinar si está ejecutándose dentro de Docker
// var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
// var keyString = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
// var connectionString = builder.Configuration.GetConnectionString(keyString);

var configuration = builder.Configuration;
var environment = configuration["Environment"];

var connectionString = environment == "Docker" ?
    configuration.GetConnectionString("ServerDB_Docker") :
    configuration.GetConnectionString("ServerDB_Local");

// Añadir servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ingrese el token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

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
builder.Services.AddScoped<IFavoritoRepository, FavoritoRepository>();
builder.Services.AddScoped<IDiaMenuRepository, DiaMenuRepository>();
builder.Services.AddScoped<IMenuSemanalRepository, MenuSemanalRepository>();

// Registrar servicios
builder.Services.AddScoped<IRecetaService, RecetaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IIngredienteService, IngredienteService>();
builder.Services.AddScoped<IRecetaIngredienteService, RecetaIngredienteService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IFavoritoService, FavoritoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDiaMenuService, DiaMenuService>();
builder.Services.AddScoped<IMenuSemanalService, MenuSemanalService>();

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
app.UseAuthorization();
app.MapControllers();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<RecetasRedondasAppContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Error durante la migración de la base de datos.");
    }
}

app.Run();
