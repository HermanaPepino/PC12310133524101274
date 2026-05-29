using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using TALLERMECÁNICO.CORE.Core.DTOs;

namespace PC12310133524101274.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicioController: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("GetAll");
            //ASDASDAS
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var result = new TipoServicioDTO
            {
                Id = id,
                Nombre = "Tipo Servicio " + id,
                Descripcion = "Descripción del tipo de servicio " + id,
                Precio = 100.00m
            };
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var result = new TipoServicioDTO
            {
                Id = 1,
                Nombre = "Tipo Servicio 1",
                Descripcion = "Descripción del tipo de servicio 1",
                Precio = 100.00m
            }; return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var result = new TipoServicioDTO
            {
                Id = id,
                Nombre = "Tipo Servicio " + id,
                Descripcion = "Descripción del tipo de servicio " + id,
                Precio = 150.00m
            };return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = new TipoServicioDTO
            {
                Id = id,
                Nombre = "Tipo Servicio " + id,
                Descripcion = "Descripción del tipo de servicio " + id,
                Precio = 0.00m
            }; return Ok(result);
        }

    }
}
