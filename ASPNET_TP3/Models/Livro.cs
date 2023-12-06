using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNET_TP3.Models
{
    public class Livro
    {
        [Key]
        public string ISBN { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Sinopse { get; set; }

        [Required]
        public DateTime DataDePublicacao { get; set; }

        [Required]
        [ForeignKey("Autor")]
        public int AutorId { get; set; }

        [Required]
        [ForeignKey("Genero")]
        public int GeneroId { get; set; }

        public Autor Autor { get; set; }
        public Genero Genero { get; set; }
    }
}
