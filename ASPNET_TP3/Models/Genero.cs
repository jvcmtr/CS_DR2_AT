using System.ComponentModel.DataAnnotations;

namespace ASPNET_TP3.Models
{
    public class Genero
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
