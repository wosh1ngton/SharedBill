using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LoginAPI.Models
{
  
    public class Usuario 
    {       
                
        public string? Email { get; set; }    
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}