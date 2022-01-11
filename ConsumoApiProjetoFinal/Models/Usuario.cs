using System.ComponentModel.DataAnnotations;

namespace ConsumoApiProjetoFinal.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informar Login")]
        public string User { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informar Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
