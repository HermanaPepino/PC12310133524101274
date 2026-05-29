using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TALLERMECÁNICO.CORE.Core.DTOs;

namespace TALLERMECÁNICO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenServicioController : ControllerBase
    {
        private readonly IOrdenServicioService _ordenServicioService;

        public OrdenServicioController(IOrdenServicioService ordenServicioService)
        {
            _ordenServicioService = ordenServicioService;
        }

        // GET: api/OrdenServicio
        [HttpGet]
        public async Task<IActionResult> GetOrdenesServicio()
        {
            var ordenes = await _ordenServicioService.GetOrdenesServicio();
            return Ok(ordenes);
        }

        // GET: api/OrdenServicio/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdenServicioById(int id)
        {
            var orden = await _ordenServicioService.GetOrdenServicioById(id);

            if (orden == null)
            {
                return NotFound();
            }

            return Ok(orden);
        }

        // POST: api/OrdenServicio
        [HttpPost]
        public async Task<IActionResult> CreateOrdenServicio([FromBody] OrdenServicioCreateDTO ordenServicioCreateDTO)
        {
            if (ordenServicioCreateDTO == null)
            {
                return BadRequest();
            }

            await _ordenServicioService.CreateOrdenServicio(ordenServicioCreateDTO);

            return Ok();
        }

        // PUT: api/OrdenServicio
        [HttpPut]
        public async Task<IActionResult> UpdateOrdenServicio([FromBody] OrdenServicioUpdateDTO ordenServicioUpdateDTO)
        {
            if (ordenServicioUpdateDTO == null)
            {
                return BadRequest();
            }

            var existingOrden = await _ordenServicioService
                .GetOrdenServicioById(ordenServicioUpdateDTO.Id);

            if (existingOrden == null)
            {
                return NotFound();
            }

            await _ordenServicioService.UpdateOrdenServicio(ordenServicioUpdateDTO);

            return NoContent();
        }

        // DELETE: api/OrdenServicio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenServicio(int id)
        {
            var existingOrden = await _ordenServicioService.GetOrdenServicioById(id);

            if (existingOrden == null)
            {
                return NotFound();
            }

            var deleteDTO = new OrdenServicioDeleteDTO
            {
                Id = id
            };

            await _ordenServicioService.DeleteOrdenServicio(deleteDTO);

            return NoContent();
        }
    }
}