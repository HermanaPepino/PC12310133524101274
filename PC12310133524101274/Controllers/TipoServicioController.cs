using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


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
            return Ok($"GetById: {id}");
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok("Create");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            return Ok($"Update: {id}");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok($"Delete: {id}");
        }

    }
}
