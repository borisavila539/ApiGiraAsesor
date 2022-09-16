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
    public class EmpresaController : ControllerBase
    {
        public readonly IEmpresaRepository _empresaRepository;
        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        [HttpGet("{empresa}")]
        public async Task<IActionResult> GetEmpresa(string empresa)
        {
            var documento = await _empresaRepository.GetEmpresa(empresa);
            return Ok(documento);
        }
    }
}