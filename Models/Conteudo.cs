using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class Conteudo
    {
        [Key]
        public int ConteudoId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200, ErrorMessage = "O título pode ter no máximo 200 caracteres.")]
        public string Titulo { get; set; }

        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo de conteúdo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo pode ter no máximo 50 caracteres.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "A data de publicação é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        public ICollection<Interacao> Interacoes { get; set; }
        public ICollection<FeedbackUsuario> Feedbacks { get; set; }
    }
}
