namespace ProjetoCuidar_API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string nomeUsuario { get; set; }
        public string senhaUsuario { get; set; }
        public string emailUsuario { get; set; }
        public string telefone { get; set; }
        public string enderecoUsuario { get; set; }
        public string fotoUsuario { get; set; }
    }
}