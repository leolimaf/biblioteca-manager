using LivrosAPI.Data;
using LivrosAPI.Services;
using LivrosAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
builder.Services.AddScoped<ILivroService, LivroService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo
    {
        Title = "Gerenciamento de Livros - Web API",
        Version = "v1",
        Description = "API RESTful para realizar o gerenciamento de bibliotecas e livrarias.",
        Contact = new OpenApiContact
        {
            Name = "Leonardo Lima",
            Url = new Uri("https://github.com/leolimaf/LivrosAPI")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts => opts.DocumentTitle = "Controle de Livros - API");
}

app.UseHttpsRedirection();

app.UseApiVersioning();

app.UseSwagger();

app.UseSwaggerUI(opts =>
{
    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de Livros - API");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseAuthorization();

app.MapControllers();

app.Run();