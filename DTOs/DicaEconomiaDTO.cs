using System.ComponentModel.DataAnnotations;

namespace Sessions_app.DTOs
{
    public class DicaEconomiaDTO
    {
        [Required]
        public int DicaId { get; set; } 

        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }

        [StringLength(1000)]
        public string Descricao { get; set; }

        public DateTime DataPublicacao { get; set; } = DateTime.Now;
    }
}
