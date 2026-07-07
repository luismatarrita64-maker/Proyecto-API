using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Reservacion
{
    public int IdReserva { get; set; }

    public int IdCliente { get; set; }

    public int IdHorario { get; set; }

    public int CantidadPersonas { get; set; }

    public decimal MontoTotal { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Horario IdHorarioNavigation { get; set; } = null!;

    public virtual Pago? Pago { get; set; }
}
