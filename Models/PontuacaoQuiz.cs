using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeuProjeto.Models
{
    public class PontuacaoQuiz
    {
        [Key]
        public int PontuacaoId { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O ID do quiz é obrigatório.")]
        public int QuizId { get; set; }

        [Required(ErrorMessage = "A pontuação é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A pontuação deve ser um valor positivo.")]
        public int Pontuacao { get; set; }

        [Required(ErrorMessage = "A data de participação é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataParticipacao { get; set; }

        public Usuario Usuario { get; set; }
    }
}
