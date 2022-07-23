using LivrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosAPI.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext(){ }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Livro> Livros { get; set; }
}