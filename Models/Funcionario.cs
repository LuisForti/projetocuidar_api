using System.ComponentModel.DataAnnotations;

namespace ProjetoCuidar_API.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(20, ErrorMessage="O nome deve ter, no máximo, 20 caracteres!")]
        [MinLength(2, ErrorMessage="O nome deve ter, no mínimo, 2 caracteres!")]
        public string nomeFuncionario { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(20, ErrorMessage="A senha deve ter, no máximo, 20 caracteres!")]
        public string senhaFuncionario { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(40, ErrorMessage="O email deve ter, no máximo, 40 caracteres!")]
        public string emailFuncionario { get; set; }

        [MaxLength(200, ErrorMessage="A foto deve ter, no máximo, 200 caracteres!")]
        public string fotoFuncionario { get; set; }
    }
}