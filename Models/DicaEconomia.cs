using System;
using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class DicaEconomia
    {
        [Key]
        public int DicaId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200, ErrorMessage = "O título pode ter no máximo 200 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de publicação é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }
    }
}
