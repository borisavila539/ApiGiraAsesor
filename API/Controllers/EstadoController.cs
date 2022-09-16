using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadosRepository _estadosRepository;
        public EstadoController(IEstadosRepository estadosRepository)
        {
            _estadosRepository = estadosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstados()
        {
            
            var estado = await _estadosRepository.GetEstados();
            return Ok(estado);
        }
    }
}
