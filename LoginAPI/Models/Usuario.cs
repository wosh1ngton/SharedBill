using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LoginAPI.Models
{
  
    public class Usuario 
    {       
                
        public string? Username { get; set; }
        public string? Role { get; set; }    
        public string? Email { get; set; }    
        public bool RememberMe { get; set; }
        public string Password { get; set; }
    }
}