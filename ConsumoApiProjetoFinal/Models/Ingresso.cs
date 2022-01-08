using System.ComponentModel.DataAnnotations;

namespace ConsumoApiProjetoFinal.Models
{
    public class Ingresso
    {
        [Key]
        public int Id { get; set; }
        public double ValorFinal { get; set; }
        public virtual TipoIngresso TipoIngresso { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public Ingresso()
        {
        }
    }
}
