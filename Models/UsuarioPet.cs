using System.ComponentModel.DataAnnotations;

namespace ProjetoCuidar_API.Models
{
    public class UsuarioPet
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O id do usuário é obrigatório")]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O id do pet é obrigatório")]
        public int idPet { get; set; }
        public string dataDeAdocao { get; set; }
    }
}