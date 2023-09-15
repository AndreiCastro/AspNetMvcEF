using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve ter entre {2} a {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Sobrenome deve ter entre {2} a {1} caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail informado inválido.")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "O Telefone informado é inválido")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Telfone deve ter entre {2} a {1} caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Digite o documento do contato")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Documento deve ter entre {2} a {1} caracteres.")]
        public string Documento { get; set; }
    }
}
