using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroMonedaController : ControllerBase
    {
        private readonly IMaestroMonedaRepository _maestroMonedaRepository;

        public MaestroMonedaController(IMaestroMonedaRepository maestroMonedaRepository)
        {
            _maestroMonedaRepository = maestroMonedaRepository;
        }

        [HttpGet("{empresa}")]
        public async Task<IActionResult> GetMaestroMoneda(string empresa)
        {
            var moneda = await _maestroMonedaRepository.GetMaestroMoneda(empresa);
            return Ok(moneda);
        }
    }
}