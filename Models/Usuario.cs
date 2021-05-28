using System.ComponentModel.DataAnnotations;

namespace ProjetoCuidar_API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(20, ErrorMessage="O nome deve ter, no máximo, 20 caracteres!")]
        [MinLength(2, ErrorMessage="O nome deve ter, no mínimo, 2 caracteres!")]
        public string nomeUsuario { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(50, ErrorMessage="A senha deve ter, no máximo, 50 caracteres!")]
        public string senhaUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(40, ErrorMessage="O email deve ter, no máximo, 40 caracteres!")]
        public string emailUsuario { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [MaxLength(20, ErrorMessage="O telefone deve ter 11 caracteres!")]
        [MinLength(2, ErrorMessage="O telefone deve ter 11 caracteres!")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [MaxLength(100, ErrorMessage="O endereço deve ter, no máximo, 100 caracteres!")]
        public string enderecoUsuario { get; set; }

        [MaxLength(200, ErrorMessage="A foto deve ter, no máximo, 200 caracteres!")]
        public string fotoUsuario { get; set; }
    }
}