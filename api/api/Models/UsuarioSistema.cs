using System;
using System.Collections.Generic;

namespace api.Models;

public partial class UsuarioSistema
{
    public int IdUsuario { get; set; }

    public int? IdOperador { get; set; }

    public int? IdCliente { get; set; }

    public string Correo { get; set; } = null!;

    public string ContrasenaHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Operador? IdOperadorNavigation { get; set; }
}
