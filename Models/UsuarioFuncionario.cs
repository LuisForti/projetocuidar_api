using System.ComponentModel.DataAnnotations;

namespace ProjetoCuidar_API.Models
{
    public class UsuarioFuncionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O id da tabela usuarioPet é obrigatório")]
        public int idUsuarioPet { get; set; }

        [Required(ErrorMessage = "O id do funcionário é obrigatório")]
        public int idFuncionario { get; set; }

        public string dataDeAdocao { get; set; }
    }
}