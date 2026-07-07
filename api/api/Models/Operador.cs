using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Operador
{
    public int IdOperador { get; set; }

    public string NombreNegocio { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string PlanSuscripcion { get; set; } = null!;

    public decimal ComisionesPorcentaje { get; set; }

    public DateTime FechaRegistro { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();

    public virtual ICollection<UsuarioSistema> UsuarioSistemas { get; set; } = new List<UsuarioSistema>();
}
