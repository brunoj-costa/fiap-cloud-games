namespace FCG.Application.Usuarios;

public class NovoUsuarioDTO
{
    public Guid Id { get; set; }
        
    public required string Nome { get; set; }

    public required string Email { get; set; }

    public TipoUsuarioDTO TipoUsuario { get; set; }
}
