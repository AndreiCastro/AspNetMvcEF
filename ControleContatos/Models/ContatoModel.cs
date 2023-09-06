using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        [Display(Name ="TestName")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o sobrenome do contato")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "O Telefone informado é inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Digite o documento do contato")]
        public string Documento { get; set; }
    }
}
