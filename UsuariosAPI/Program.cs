using LivrosAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UserDbContext>(opts =>
{
    opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("UserConnectionString"), new MySqlServerVersion(new Version(8, 0, 22)));
});
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddEntityFrameworkStores<UserDbContext>();
builder.Services.AddControllers();
builder.Services.AddScoped<UsuarioService, UsuarioService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();