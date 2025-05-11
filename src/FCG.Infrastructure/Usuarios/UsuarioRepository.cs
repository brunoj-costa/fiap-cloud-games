using FCG.Domain.Usuarios;
using FCG.Infrastructure.Base;
using FCG.Infrastructure.Context;

namespace FCG.Infrastructure.Usuarios;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(FCGDbContext context) : base(context) { }

}
