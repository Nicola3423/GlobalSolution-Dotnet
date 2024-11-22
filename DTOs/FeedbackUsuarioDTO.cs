using System.ComponentModel.DataAnnotations;

namespace Sessions_app.DTOs
{
    public class FeedbackUsuarioDTO
    {
        [Required]
        public int FeedbackId { get; set; } 

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int ConteudoId { get; set; }

        [Required]
        [StringLength(500)]
        public string Mensagem { get; set; }

        public DateTime DataFeedback { get; set; } = DateTime.Now;
    }
}
