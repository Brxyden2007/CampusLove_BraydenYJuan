using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; // Importante para [Table] y [Column]
using System.Linq;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities;

namespace CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities;

// El nombre de la tabla debe ser "interesusuario" para coincidir con tu DDL
[Table("interesusuario")]
public class UsuarioInteres
{
    // ¡CRUCIAL! Propiedad C# renombrada a 'usuario_id' para coincidir con la columna SQL
    [Column("usuario_id")] // Atributo para ser explícitos
    public int usuario_id { get; set; }
    public Usuario? Usuario { get; set; }

    // ¡CRUCIAL! Propiedad C# renombrada a 'interes_id' para coincidir con la columna SQL
    [Column("interes_id")] // Atributo para ser explícitos
    public int interes_id { get; set; }
    public Interes? Interes { get; set; }
}
