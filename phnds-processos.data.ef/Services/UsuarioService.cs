using AutoMapper;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Usuario;

namespace phnds_processos.data.ef.Services
{
    public class UsuarioService : BaseService<UsuarioEntity,UsuarioCommand>, IUsuarioService
    {
        public UsuarioService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
