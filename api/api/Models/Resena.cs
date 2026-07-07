using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Resena
{
    public int IdResena { get; set; }

    public int IdCliente { get; set; }

    public int IdTour { get; set; }

    public string Gmail { get; set; } = null!;

    public string Resena1 { get; set; } = null!;

    public DateTime FechaResena { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Tour IdTourNavigation { get; set; } = null!;
}
