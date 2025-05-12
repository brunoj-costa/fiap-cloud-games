using FCG.Domain.Usuarios;

namespace FCG.Application.Usuarios;

public interface IUsuarioService : IDisposable
{
    Task<NovoUsuarioDTO> Adicionar(UsuarioDTO usuario);
}

public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
{
    public async Task<NovoUsuarioDTO> Adicionar(UsuarioDTO usuario)
    {
        var usuarioAdicionado = await usuarioRepository.Adicionar(new Usuario
        {
            Nome = usuario.Nome,
            Email = usuario.Email,
            Senha = usuario.Senha,
            TipoUsuario = (TipoUsuario)usuario.TipoUsuario
        });

        return new NovoUsuarioDTO
        {
            Id = usuarioAdicionado.Id,
            Nome = usuarioAdicionado.Nome,
            Email = usuarioAdicionado.Email,
            TipoUsuario = (TipoUsuarioDTO)usuarioAdicionado.TipoUsuario
        };
    }

    public void Dispose()
    {
        usuarioRepository?.Dispose();
    }
}
