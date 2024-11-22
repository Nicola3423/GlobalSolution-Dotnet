using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeuProjeto.Models
{
    public class Interacao
    {
        [Key]
        public int InteracaoId { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O ID do conteúdo é obrigatório.")]
        [ForeignKey("Conteudo")]
        public int ConteudoId { get; set; }

        [Required(ErrorMessage = "O tipo de interação é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo de interação pode ter no máximo 50 caracteres.")]
        public string TipoInteracao { get; set; }

        [Required(ErrorMessage = "A data da interação é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataInteracao { get; set; }

        public Usuario Usuario { get; set; }
        public Conteudo Conteudo { get; set; }
    }
}
