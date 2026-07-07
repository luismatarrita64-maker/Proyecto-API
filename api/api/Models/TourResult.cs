using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class TourResult
    {
        [Column("id_tour")]
        public int IdTour { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = null!;

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("precio_usd")]
        public decimal PrecioUsd { get; set; }

        [Column("precio_colones")]
        public decimal PrecioColones { get; set; }

        [Column("capacidad")]
        public int Capacidad { get; set; }

        [Column("duracion")]
        public int Duracion { get; set; }

        [Column("estado")]
        public string Estado { get; set; } = null!;

        [Column("nombre_negocio")]
        public string? NombreNegocio { get; set; }
    }

    public class MensajeResult
    {
        public string Mensaje { get; set; } = null!;
    }
}