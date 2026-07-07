using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdReserva { get; set; }

    public string Metodo { get; set; } = null!;

    public string Moneda { get; set; } = null!;

    public decimal Monto { get; set; }

    public string? ReferenciaExterna { get; set; }

    public DateTime FechaPago { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Reservacion IdReservaNavigation { get; set; } = null!;
}
