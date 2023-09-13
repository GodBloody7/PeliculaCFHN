using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PeliculaCFHN.EntidadeDeNegocio;
using PeliculaCFHN.LogicaDeNegocio;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace PeliculaCFHN.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PeliculaController : ControllerBase
    {
        private PeliculaBL peliculaBL = new PeliculaBL();

        [HttpGet]
        public async Task<IEnumerable<Pelicula>> Get()
        {
            return await peliculaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Pelicula> Get(int id)
        {
            Pelicula pelicula = new Pelicula();
            pelicula.Id = id;
            return await peliculaBL.ObtenerPorIdAsync(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pelicula pelicula)
        {
            try
            {
                await peliculaBL.CrearAsync(pelicula);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pPelicula)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strPelicula = JsonSerializer.Serialize(pPelicula);
            Pelicula pelicula = JsonSerializer.Deserialize<Pelicula>(strPelicula, option);
            if (pelicula.Id == id)
            {
                await peliculaBL.ModificarAsync(pelicula);
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
                Pelicula pelicula = new Pelicula();
                pelicula.Id = id;
                await peliculaBL.EliminarAsync(pelicula);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Pelicula>> Buscar([FromBody] object pPelicula)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strPelicula = JsonSerializer.Serialize(pPelicula);
            Pelicula pelicula = JsonSerializer.Deserialize<Pelicula>(strPelicula, option);
            var peliculas = await peliculaBL.BuscarIncluirRelacionesAsync(pelicula);
            peliculas.ForEach(s => s.Genero.Pelicula = null);
            peliculas.ForEach(s => s.Director.Pelicula = null);
            return peliculas;
        }
    }
}
