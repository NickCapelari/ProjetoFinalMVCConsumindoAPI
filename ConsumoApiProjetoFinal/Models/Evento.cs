using System.ComponentModel.DataAnnotations;

namespace ConsumoApiProjetoFinal.Models
{
    public class Evento
    {
        [Key]
        [Display(Name = "ID Evento: ")]
        public int Id { get; set; }

        [Display(Name = "Nome do Evento: ")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Descrição do Evento: ")]
        [StringLength(300)]
        public string Descricao { get; set; }

        [Display(Name = "Data de Inicio: ")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Encerramento: ")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataFim { get; set; }

        [Display(Name = "Valor do Ingresso: ")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }


        public virtual ICollection<Ingresso> Ingressos { get; set; }
        public virtual LocalEvento LocalEvento { get; set; }

        [Display(Name = "Local do Evento: ")]
        public int LocalEventoId { get; set; }


        public Evento()
        {
        }
    }
}
