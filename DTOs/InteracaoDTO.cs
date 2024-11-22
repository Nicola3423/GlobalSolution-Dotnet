using System.ComponentModel.DataAnnotations;

namespace Sessions_app.DTOs
{
    public class InteracaoDTO
    {
        [Required]
        public int InteracaoId { get; set; } // ID fornecido manualmente

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int ConteudoId { get; set; }

        [StringLength(50)]
        public string TipoInteracao { get; set; }

        public DateTime DataInteracao { get; set; } = DateTime.Now;
    }
}
