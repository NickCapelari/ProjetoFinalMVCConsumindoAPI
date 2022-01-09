using System.ComponentModel.DataAnnotations;

namespace ConsumoApiProjetoFinal.Models
{
    public class FotoPortifolio
    {
        [Key]
        public int Id { get; set; }
        public string CaminhoFoto { get; set; }
        public int PortifolioId { get; set; }
        public virtual Portifolio? Portifolio { get; set; }

        public FotoPortifolio()
        {
        }
    }
}
