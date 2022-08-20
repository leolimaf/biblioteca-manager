using BibliotecaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWebApi.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext(){ }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        builder.Entity<Emprestimo>()
            .HasOne(emprestimo => emprestimo.Livro)
            .WithMany(livro => livro.Emprestimos)
            .HasForeignKey(emprestimo => emprestimo.LivroId);
        
        builder.Entity<Emprestimo>()
            .HasOne(emprestimo => emprestimo.Usuario)
            .WithMany(usuario => usuario.Emprestimos)
            .HasForeignKey(emprestimo => emprestimo.UsuarioId);
        
        builder.Entity<Livro>()
            .HasOne(livro => livro.Autor)
            .WithMany(autor => autor.Livros)
            .HasForeignKey(livro => livro.AutorId);        
        
        builder.Entity<Livro>()
            .HasOne(livro => livro.Editora)
            .WithMany(editora => editora.Livros)
            .HasForeignKey(livro => livro.EditoraId);
    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Editora> Editoras { get; set; }
    public DbSet<Emprestimo> Emprestimos { get; set; }
}