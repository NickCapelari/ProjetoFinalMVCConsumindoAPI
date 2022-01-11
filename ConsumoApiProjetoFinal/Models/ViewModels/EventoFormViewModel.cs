namespace ConsumoApiProjetoFinal.Models.ViewModels
{
    public class EventoFormViewModel
    {
        public Evento Evento { get; set; }
        public LocalEvento LocalEvento { get; set; }
        public List<LocalEvento> LocalEventos { get; set; }
    }
}
