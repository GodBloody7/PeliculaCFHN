using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculaCFHN.LogicaDeNegocio;

namespace PeliculaCFHN.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private DirectorBL directorBL = new DirectorBL();
    }
}
