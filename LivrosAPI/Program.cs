using System.Reflection;
using LivrosAPI.Data;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("MySQLConnectionString"), new MySqlServerVersion(new Version(8, 0, 22)));
});
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMvc(opts =>
{
    opts.RespectBrowserAcceptHeader = true;
    opts.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    opts.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
}).AddXmlSerializerFormatters();
builder.Services.AddApiVersioning(opts =>
{
    opts.DefaultApiVersion = new ApiVersion(1, 0);
    opts.ReportApiVersions = true;
    opts.AssumeDefaultVersionWhenUnspecified = true;
});
builder.Services.AddVersionedApiExplorer(opts =>
{
    opts.GroupNameFormat = "'v'VVV";
    opts.SubstituteApiVersionInUrl = true;
});
builder.Services.AddScoped<BibliotecaService, BibliotecaService>();
builder.Services.AddScoped<AutorService, AutorService>();
builder.Services.AddScoped<EditoraService, EditoraService>();
builder.Services.AddScoped<EmprestimoService, EmprestimoService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1",new OpenApiInfo
    {
        Title = "Biblioteca Virtual - Web API",
        Version = "v1",
        Description = "Web API REST desenvolvida para realizar o gerenciamento online de bibliotecas.",
        Contact = new OpenApiContact
        {
            Name = "Leonardo Lima",
            Url = new Uri("https://github.com/leolimaf/LivrosAPI")
        }
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts => opts.DocumentTitle = "Biblioteca Virtual - Web API");
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseApiVersioning();

app.UseSwagger();

app.UseSwaggerUI(opts =>
{
    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca Virtual - Web API");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseAuthorization();

app.MapControllers();

app.Run();