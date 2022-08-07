using LivrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosAPI.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext(){ }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // TODO: AJUSTAR RELACIONAMENTO MUITOS PRA MUITOS / AUTORES - LIVROS
        builder.Entity<Livro>()
            .HasMany(livro => livro.Autores)
            .WithMany(autor => autor.Livros);
        
        builder.Entity<Livro>()
            .HasOne(livro => livro.Editora)
            .WithMany(editora => editora.Livros)
            .HasForeignKey(livro => livro.EditoraId);
    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Editora> Editoras { get; set; }
}