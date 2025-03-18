using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OdontoPrevAPI.Data;
using OdontoPrevAPI.Repositories;
using OdontoPrevAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// configuração do BD
var connectionString = ConfigManager.Instance.ConnectionString;
builder.Services.AddDbContext<OdontoPrevContext>(options =>
    options.UseOracle(connectionString), ServiceLifetime.Scoped);

// registro dos repositórios
builder.Services.AddScoped<PacienteRepository>();
builder.Services.AddScoped<TratamentoRepository>();
builder.Services.AddScoped<SinistroRepository>();

// config dos serviços da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// config do swagger para documentação da API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OdontoPrev API",
        Version = "v1",
        Description = "API para gerenciamento de pacientes, tratamentos e sinistros odontológicos."
    });

    // para icluir documentação XML gerada automaticamente
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// config do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// ativa o CORS na aplicação
app.UseCors("AllowAllOrigins");

// config do pipeline da API

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
