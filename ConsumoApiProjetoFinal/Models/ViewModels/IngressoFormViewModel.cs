namespace ConsumoApiProjetoFinal.Models.ViewModels
{
    public class IngressoFormViewModel
    {
        public Ingresso Ingresso { get; set; }
        public List<Ingresso> Ingressos { get; set; }
        public List<Pessoa> Pessoa { get; set; }
        public List<TipoIngresso> TipoIngresso { get; set; } 
        public List<Evento> Evento { get; set; } 
    }
}
