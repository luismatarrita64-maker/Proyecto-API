using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int IdTour { get; set; }

    public int IdGuia { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public int CuposDisponible { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Guium IdGuiaNavigation { get; set; } = null!;

    public virtual Tour IdTourNavigation { get; set; } = null!;

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}
