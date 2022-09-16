using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Core.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuariosRepository _usuariosRepository;
        public  UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuarios(DatosCorreoDTO datos)
        {
            await _usuariosRepository.PostUsuarioByUser(datos);
            //var usuarioDto = new { usuario=usuario.Usuario,empresa=usuario.EmpresaId,nombre=usuario.Nombre,correo=usuario.Correo};
            return Ok("Correo Enviado");
        }

    }
}