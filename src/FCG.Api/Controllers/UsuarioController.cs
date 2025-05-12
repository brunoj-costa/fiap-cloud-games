using FCG.Application.Usuarios;
using FCG.Domain.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Adicionar(UsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var novoUsuario = await usuarioService.Adicionar(usuario);

            return CreatedAtAction(nameof(Adicionar), new { id = novoUsuario.Id }, novoUsuario);
        }
    }
}
