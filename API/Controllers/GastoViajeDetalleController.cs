using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoViajeDetalleController : ControllerBase
    {
        public readonly IGastoViajeDetalleRepository _gastoviajedetalleRepository;
        public GastoViajeDetalleController(IGastoViajeDetalleRepository gastoviajedetalleRepository)
        {
            _gastoviajedetalleRepository = gastoviajedetalleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGastoViajeDetalle()
        {
            var historial = await _gastoviajedetalleRepository.GetGastoViajeDetalle();
            return Ok(historial);
        }

        [HttpGet("{UsuarioAsesor}/{inicio}/{fin}/{page}/{size}/{estado}")]
        public async Task<IActionResult> GetGastoViajeDetalle(string UsuarioAsesor, DateTime inicio, DateTime fin, int page, int size, int estado)
        {
            var historial = await _gastoviajedetalleRepository.GetGastoViajeDetalle(UsuarioAsesor, inicio, fin, page, size, estado);
            return Ok(historial);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGastoViajeDetalle(int id)
        {
            var historial = await _gastoviajedetalleRepository.GetGastoViajeDetalle(id);
            return Ok(historial);
        }

        [HttpGet]
        [Route("Imagen/{id}")]
        public async Task<IActionResult> GetGastoViajeDetalleImagen(int id)
        {
            var imagen = await _gastoviajedetalleRepository.GetGastoViajeDetalleImagen(id);
            return Ok(imagen);
        }

   
        [HttpGet("{Usuario}/{idEstado}/{page}/{size}")]
        public async Task<IActionResult> GetGastoViajeDetalle(string usuario, int idEstado,int page, int size)
        {
            var historial = await _gastoviajedetalleRepository.GetGastoViajeDetalle(usuario,idEstado, page,size);
            return Ok(historial);
        }

        [HttpGet("{Usuario}/{page}/{size}")]
        public async Task<IActionResult> GetGastoViajeDetalle(string usuario, int page, int size)
        {
            var historial = await _gastoviajedetalleRepository.GetGastoViajeDetalle(usuario, page, size);
            return Ok(historial);
        }

        [HttpGet]
        [Route("Pendientes/{idEstado}/{page}/{size}/{empresa}")]
        public async Task<IActionResult> GetGastoViajeDetalle( int idEstado, int page, int size, string empresa)
        {
            var historial = await _gastoviajedetalleRepository.GetGastoViajeDetalle(idEstado, page, size, empresa);
            return Ok(historial);
        }

        [HttpGet("{usuario}/{id}")]
        public  int GetGastoViajeDetalle(string usuario, int id)
        {
            var num =  _gastoviajedetalleRepository.GetGastoViajeDetalle(usuario, id);
            return num;
        }

       
        [HttpGet]
        [Route("verificar/{noFactura}")]
        public async Task<IActionResult> GetGastoViajeDetalle(string noFactura)
        {
            var result =  await _gastoviajedetalleRepository.GetGastoViajeDetalleVerificar(noFactura);
            return Ok(result);
        }



        [HttpPost]
        public async Task<IActionResult> PostGastoViajeDetalle(GastosViajeDetalleEntity gastoviajedetalle)
        {
           await _gastoviajedetalleRepository.PostGastoViajeDetalle(gastoviajedetalle);  
            return Ok(gastoviajedetalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGastoViajeDetalle(int id, GastosViajeDetalleEntity gasto)
        {
            if(id == gasto.IdGastoViajeDetalle)
            {
                await _gastoviajedetalleRepository.PutGastoViajeDetalle(id, gasto);
                return Ok("Modificado");
            }

            return BadRequest();
        }


    }
}