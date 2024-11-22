using System.ComponentModel.DataAnnotations;

namespace Sessions_app.DTOs
{
    public class PontuacaoQuizDTO
    {
        [Required]
        public int PontuacaoId { get; set; } 

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int QuizId { get; set; }

        [Required]
        public int Pontuacao { get; set; }

        public DateTime DataParticipacao { get; set; } = DateTime.Now;
    }
}
