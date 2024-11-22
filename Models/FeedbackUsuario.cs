using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeuProjeto.Models
{
    public class FeedbackUsuario
    {
        [Key]
        public int FeedbackId { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O ID do conteúdo é obrigatório.")]
        [ForeignKey("Conteudo")]
        public int ConteudoId { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        [StringLength(500, ErrorMessage = "A mensagem pode ter no máximo 500 caracteres.")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "A data do feedback é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataFeedback { get; set; }

        public Usuario Usuario { get; set; }
        public Conteudo Conteudo { get; set; }
    }
}
