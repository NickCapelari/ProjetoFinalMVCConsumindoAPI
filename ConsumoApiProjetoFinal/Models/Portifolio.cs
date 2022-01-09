using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ConsumoApiProjetoFinal.Models
{
    public class Portifolio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nome: ")]
        public string Name { get; set; }
        [Required]
        [StringLength(400)]
        [Display(Name = "Descrição: ")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Foto Miniatura: ")]
        public string CaminhoFotoPrincipal { get; set; }
        
        [Display(Name = "Fotos do Portifolio: ")]
        public virtual ICollection<FotoPortifolio>? FotosPortifolio { get; set; } = new List<FotoPortifolio>();

        public Portifolio()
        {
        }
    }
}
