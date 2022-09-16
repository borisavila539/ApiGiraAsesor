using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaTipoGastoViajeController : ControllerBase
    {
        private readonly ICategoriaTipoGastoViajeRepository _categoriatipogastoRepository;
        public CategoriaTipoGastoViajeController(ICategoriaTipoGastoViajeRepository categoriatipogastoRepository)
        {
            _categoriatipogastoRepository = categoriatipogastoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriaTipoGastoViaje()
        {
            var categoria = await _categoriatipogastoRepository.GetCategoriaTipoGastoViajeEntities();
            return Ok(categoria);
        }

        [HttpGet("{empresa}")]
        public async Task<IActionResult> GetCategoriaTipoGastoViaje(string empresa)
        {
            var categoria = await _categoriatipogastoRepository.GetCategoriaTipoGastoViajeEntities(empresa);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoriaTipoGastoViaje(CategoriaTipoGastoViajeEntity categoriaTipoGastoViaje)
        {
            await _categoriatipogastoRepository.PostCategoriaTipoGastoViaje(categoriaTipoGastoViaje);
            return Ok(categoriaTipoGastoViaje);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaGastoViajeDetalle(int id, CategoriaTipoGastoViajeEntity categoria)
        {
            if(id == categoria.IdCategoriaTipoGastoViaje)
            {
                await _categoriatipogastoRepository.PutCategoriaGastoViajeDetalle(id, categoria);
                return Ok("Modificado");
            }

            return BadRequest();
        }

    }
}
