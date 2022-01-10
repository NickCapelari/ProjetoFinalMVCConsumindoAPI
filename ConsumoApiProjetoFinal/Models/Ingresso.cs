using System.ComponentModel.DataAnnotations;

namespace ConsumoApiProjetoFinal.Models
{
    public class Ingresso
    {
        [Key]
        public int Id { get; set; }
        public double ValorFinal { get; set; }
        public int TipoIngressoId { get; set; }
        public int EventoId { get; set; }
        public int PessoaId { get; set; }
        public virtual TipoIngresso TipoIngresso { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public void CalculaValorIngresso(double desconto, double valorEvento)
        {
            valorEvento -= valorEvento * (desconto / 100);
            ValorFinal = valorEvento;
        }
        public Ingresso()
        {
        }
    }
}
