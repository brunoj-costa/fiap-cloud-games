using FCG.Domain.Base;

namespace FCG.Domain.Usuarios;

public class Usuario : Entity
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
}

public enum TipoUsuario
{
    Administrador = 1,
    Usuario = 2
}
