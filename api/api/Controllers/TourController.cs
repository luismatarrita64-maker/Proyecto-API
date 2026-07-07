
using api.Services;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : ControllerBase
    {
        private readonly TourService _tourService;

        public TourController(TourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener([FromQuery] TourObtenerDto dto) =>
            Ok(await _tourService.ObtenerAsync(dto));

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TourCrearDto dto) =>
            Ok(await _tourService.CrearAsync(dto));

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] TourActualizarDto dto) =>
            Ok(await _tourService.ActualizarAsync(dto));

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] TourEliminarDto dto) =>
            Ok(await _tourService.EliminarAsync(dto));
    }
}