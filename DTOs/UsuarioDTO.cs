using System.ComponentModel.DataAnnotations;

namespace Sessions_app.DTOs
{
    public class UsuarioDTO
    {
        [Required]
        public int UsuarioId { get; set; } 

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
