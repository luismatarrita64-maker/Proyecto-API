// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("api/[controller]")]
// public class ProductosController : ControllerBase
// {
//     private readonly AppDbContext _context;

//     public ProductosController(AppDbContext context)
//     {
//         _context = context;
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetAll() =>
//         Ok(await _context.Productos.ToListAsync());
// }