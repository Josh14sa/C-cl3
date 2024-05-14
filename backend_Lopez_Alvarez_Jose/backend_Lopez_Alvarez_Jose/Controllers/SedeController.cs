using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_Lopez_Alvarez_Jose.Data;
using backend_Lopez_Alvarez_Jose.Models;
using backend_Lopez_Alvarez_Jose.Data.DAO;
using backend_Lopez_Alvarez_Jose.Data.Interfaces;

namespace backend_Lopez_Alvarez_Jose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        private readonly ISede _sedeService;

        public SedeController(ISede sedeService)
        {
            _sedeService = sedeService;
        }

        [HttpGet]
        public async Task<IActionResult> listarSede()
        {
            var sede = await _sedeService.listarSede();
            return Ok(sede);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> obtenerSede([FromRoute] Guid id)
        {
            var sede = await _sedeService.obtenerSede(id);
            if (sede == null)
            {
                return NotFound();
            }
            return Ok(sede);
        }
        [HttpPost]
        public async Task<IActionResult> registrarSede(AddSede addSede)
        {
            var sede = await _sedeService.registrarSede(addSede);
            return Ok(sede);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> actualizarSede([FromRoute] Guid id, UpdateSede updateSede)
        {
            var sed = await _sedeService.actualizarSede(id, updateSede);
            if (sed == null)
            {
                return NotFound();
            }
            return Ok(sed);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> eliminarSede([FromRoute] Guid id)
        {
            var sed = await _sedeService.eliminarSede(id);

            if (sed == null)
            {
                return NotFound();
            }
            return Ok(sed);
        }




    }

}
