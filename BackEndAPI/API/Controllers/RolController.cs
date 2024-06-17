using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly DB_Context _context;
        public RolController(DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista() {
            List<Rol> lista = new List<Rol>();
            try {
                lista = await _context.Rols.ToListAsync();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

    }
}
