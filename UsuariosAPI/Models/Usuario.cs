using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LivrosAPI.Models;
public class Usuario
{
    [Key]
    [Required]
    public long Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }
}