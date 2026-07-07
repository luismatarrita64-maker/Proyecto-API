
using api.Models;
using API.Dtos;
using API.Models;
using Microsoft.Data.SqlClient;

namespace api.Services
{
    public class TourService
    {
        private readonly AppDbContext _context;

        public TourService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TourResult>> ObtenerAsync(TourObtenerDto dto)
        {
            return await _context.sp_ObtenerTours();
        }

        public async Task<TourResult?> CrearAsync(TourCrearDto dto)
        {
            return await _context.sp_CrearTour(
                dto.IdOperador,
                dto.Nombre,
                dto.Descripcion,
                dto.PrecioUsd,
                dto.PrecioColones,
                dto.Capacidad,
                dto.Duracion
            );
        }

        public async Task<TourResult?> ActualizarAsync(TourActualizarDto dto)
        {
            return await _context.sp_ActualizarTour(
                dto.IdTour,
                dto.Nombre,
                dto.Descripcion,
                dto.PrecioUsd,
                dto.PrecioColones,
                dto.Capacidad,
                dto.Duracion
            );
        }

        public async Task<MensajeResult?> EliminarAsync(TourEliminarDto dto)
        {
            return await _context.sp_EliminarTour(dto.IdTour);
        }
    }
}