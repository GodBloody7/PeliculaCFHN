using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculaCFHN.EntidadeDeNegocio;
using PeliculaCFHN.LogicaDeNegocio;
using System.Text.Json;

namespace PeliculaCFHN.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private DirectorBL directorBL = new DirectorBL();

        [HttpGet]
        public async Task<IEnumerable<Director>> Get()
        {
            return await directorBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Director> Get(int id)
        {
            Director director = new Director();
            director.Id = id;
            return await directorBL.ObtenerPorIdAsync(director);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Director director)
        {
            try
            {
                await directorBL.CrearAsync(director);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Director director)
        {
            if (director.Id == id)
            {
                await directorBL.ModificarAsync(director);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Director director = new Director();
                director.Id = id;
                await directorBL.EliminarAsync(director);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Director>> Buscar([FromBody] object pDirector)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDirector = JsonSerializer.Serialize(pDirector);
            Director director = JsonSerializer.Deserialize<Director>(strDirector, option);
            return await directorBL.BuscarAsync(director);
        }
    }
}
