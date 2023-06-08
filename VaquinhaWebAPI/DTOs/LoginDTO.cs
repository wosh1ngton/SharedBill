namespace VaquinhaWebAPI.Models
{
   
    public class LoginDTO    
    {   
        public LoginDTO(string nomeUsuario, string senha)
        {
            this.NomeUsuario = nomeUsuario;
            this.Senha = senha;
    
        }
        public string NomeUsuario { get; set; }
 
        public string Senha { get; set; }
    }
}