namespace VaquinhaWebAPI.DTOs
{    
    public class PaganteDTO
    {  
        public int Id { get; set; } 
        public required string NomePagante { get; set; }
        public string? SobrenomePagante { get; set; }
    }
}