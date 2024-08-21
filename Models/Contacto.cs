using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appwebCafe2.Models
{
    [Table("t_contacto")]
    public class Contacto //aca va con el controller para que funcione  objConctacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("Nombre")]
        public string? Nombre { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Phone")]
        public string? Phone { get; set; }

        [Column("Asunto")]
        public string? Asunto { get; set; }

        [Column("Mensaje")]
        public string? Mensaje { get; set; }

        [Column("Comentario")]
        public string? Comentario { get; set; }
    }
}