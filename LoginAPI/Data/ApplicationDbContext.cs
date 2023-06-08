using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LoginAPI.Models;

namespace LoginAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {       

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}