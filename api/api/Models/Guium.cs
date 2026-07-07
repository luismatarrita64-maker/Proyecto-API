using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Guium
{
    public int IdGuia { get; set; }

    public int IdTour { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Tour IdTourNavigation { get; set; } = null!;
}
