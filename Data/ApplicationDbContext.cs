//conexion de la base de datos con nuestras clases, conecta y crea

using appwebCafe2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace appwebCafe2.Data; // DATA Migrations se basa en los objetos 
public class ApplicationDbContext : IdentityDbContext
{
    //DataProducto se conecta con el ProductoController   
    public DbSet<Producto> DataProducto{ get; set;} //interaptuar con la base de datos

    public DbSet<Contacto> DataContacto{ get; set;}
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) //que se enlaza aca, contacto,productos
    {
    }
}
