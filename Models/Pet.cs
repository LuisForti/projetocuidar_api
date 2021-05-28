using System.ComponentModel.DataAnnotations;

namespace ProjetoCuidar_API.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(20, ErrorMessage="O nome deve ter, no máximo, 20 caracteres!")]
        [MinLength(2, ErrorMessage="O nome deve ter, no mínimo, 2 caracteres!")]
        public string nomePet { get; set; }

        [Required(ErrorMessage = "A foto é obrigatória")]
        [MaxLength(200, ErrorMessage="A foto deve ter, no máximo, 200 caracteres!")]
        public string fotoPet { get; set; }

        [Required(ErrorMessage = "A raça é obrigatória")]
        [MaxLength(20, ErrorMessage="A raça deve ter, no máximo, 20 caracteres!")]
        [MinLength(2, ErrorMessage="A raça deve ter, no mínimo, 2 caracteres!")]
        public string raca { get; set; }

        [Required(ErrorMessage = "A idade é obrigatória")]
        [Range(18, 120, ErrorMessage="A idade deve estar entre 18 e 120 anos!")]
        public int idade { get; set; }

        [Required(ErrorMessage = "As condições médicas são obrigatórias")]
        [MaxLength(20, ErrorMessage="As condições médicas devem ter, no máximo, 200 caracteres!")]
        public string condicoesMedicas { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(20, ErrorMessage="A descrição deve ter, no máximo, 500 caracteres!")]
        public string descricao { get; set; }
    }
}