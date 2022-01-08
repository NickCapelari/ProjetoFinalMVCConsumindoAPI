using System.ComponentModel.DataAnnotations;

namespace ConsumoApiProjetoFinal.Models
{
    public class TipoIngresso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Tipo { get; set; }
        [Required]
        [Range(0.1, 100)]
        public double PercentualDesconto { get; set; }
        public virtual ICollection<Ingresso> Ingressos { get; set; }




        public TipoIngresso()
        {
        }
    }
}
