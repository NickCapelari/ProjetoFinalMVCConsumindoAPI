using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ConsumoApiProjetoFinal.Models
{
    public class Pessoa
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data De Nscimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(15)]
        public string Cpf { get; set; }

        [StringLength(15)]
        public string RG { get; set; }
        public virtual ICollection<Contato>? Contatos { get; set; } = new List<Contato>();

      
        public virtual ICollection<Ingresso>? Ingressos { get; set; } = new List<Ingresso>();
        public Pessoa() { }

        public Pessoa(int id, string nome, DateTime dataNascimento, string cpf, string rG, ICollection<Contato> contatos, ICollection<Ingresso> ingressos)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            RG = rG;
            Contatos = contatos;
            Ingressos = ingressos;
        }
    }
}
