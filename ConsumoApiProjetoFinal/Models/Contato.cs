using System.ComponentModel.DataAnnotations;

namespace ConsumoApiProjetoFinal.Models
{
    public class Contato
    {
        [Key]
        [Display(Name = "ID Telefone: ")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Telefone: ")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public string Telefone { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Iserir um e-mail valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa? Pessoa { get; set; }

        public Contato()
        {
        }

        public Contato(int id, string telefone, string email, Pessoa pessoa)
        {
            Id = id;
            Telefone = telefone;
            Email = email;
            Pessoa = pessoa;
        }
    }
}
