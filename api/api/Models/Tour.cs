using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Tour
{
    public int IdTour { get; set; }

    public int IdOperador { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal PrecioUsd { get; set; }

    public decimal PrecioColones { get; set; }

    public int Capacidad { get; set; }

    public int Duracion { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Guium> Guia { get; set; } = new List<Guium>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Operador IdOperadorNavigation { get; set; } = null!;

    public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();
}
