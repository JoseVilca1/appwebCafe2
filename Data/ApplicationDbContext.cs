using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace appwebCafe2.Data; // DATA Migrations se basa en los objetos 

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) //que se enlaza aca, contacto,productos
    {
    }
}
