using AutoMapper;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Advogado;
using phnds_processos.domain.Processo;

namespace phnds_processos.data.ef.Services
{
    public class ProcessoService : BaseService<ProcessoEntity, ProcessoCommand>, IProcessoService
    {
        public ProcessoService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
