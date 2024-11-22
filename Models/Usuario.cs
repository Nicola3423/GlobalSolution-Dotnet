using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [StringLength(150, ErrorMessage = "O e-mail pode ter no máximo 150 caracteres.")]
        [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A data de cadastro é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        public ICollection<PontuacaoQuiz> Pontuacoes { get; set; }
        public ICollection<Interacao> Interacoes { get; set; }
        public ICollection<FeedbackUsuario> Feedbacks { get; set; }
    }
}
