using phnds_processos.domain.Advogado;
using phnds_processos.domain.Response;

namespace phnds_processos.domain.Processo
{
    public interface IProcessoRepository : Base.IBaseRepository<ProcessoDTO>
    {
        Task<ResponseDto<ProcessoDTO>> GetAllOfParams(int size, int page, string filter);
    }
}
