using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoGastoViajeController : ControllerBase
    {
        private readonly ITipoGastoViajeRepository _tipogastoviajeRepository;
        public TipoGastoViajeController(ITipoGastoViajeRepository tipogastoviajeRepository)
        {
            _tipogastoviajeRepository = tipogastoviajeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTipoGastoViaje()
        {
            var tipo = await _tipogastoviajeRepository.GetTipoGastoViajeEntities();
            return Ok(tipo);
        }

        [HttpGet("{empresa}")]
        public async Task<IActionResult> GetTipoGastoViaje(string empresa)
        {
            var tipo = await _tipogastoviajeRepository.GetTipoGastoViajeEntities(empresa);
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> PostTipoGastoViaje(TipoGastoViajeEntity tipo)
        {
            await _tipogastoviajeRepository.PostTipoGastoViaje(tipo);
            return Ok(tipo);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutTipoGastoViaje(int id, TipoGastoViajeEntity tipo)
        {
            if(id == tipo.IdTipoGastoViaje)
            {
                await _tipogastoviajeRepository.PutTipoGastoViaje(id, tipo);
                return Ok("Modificado");
            }

            return BadRequest();
        }

    }
}
