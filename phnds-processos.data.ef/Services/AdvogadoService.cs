using AutoMapper;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Advogado;

namespace phnds_processos.data.ef.Services
{
    public class AdvogadoService : BaseService<AdvogadoEntity,AdvogadoCommand>, IAdvogadoService
    {
        public AdvogadoService(DatabaseContext context, IMapper mapper) : base(context,mapper)
        {
        }
    }
}
