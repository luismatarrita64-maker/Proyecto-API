namespace API.Dtos
{
    public class TourObtenerDto
    {
        
    }

    public class TourCrearDto
    {
        public int IdOperador { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal PrecioUsd { get; set; }
        public decimal PrecioColones { get; set; }
        public int Capacidad { get; set; }
        public int Duracion { get; set; }
    }

    public class TourActualizarDto
    {
        public int IdTour { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? PrecioUsd { get; set; }
        public decimal? PrecioColones { get; set; }
        public int? Capacidad { get; set; }
        public int? Duracion { get; set; }
    }

    public class TourEliminarDto
    {
        public int IdTour { get; set; }
    }
}

