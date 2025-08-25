using AutoMapper;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Andamento;

namespace phnds_processos.data.ef.Repositories
{
    public class AndamentoRepository : BaseRepository<AndamentoEntity, AndamentoDTO>, IAndamentoRepository
    {
        public AndamentoRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ICollection<AndamentoDTO>> GetAndamentosProcesso(Guid processoCode)
        {
            var andamentos = await _dbSet.Where(x => !x.Apagado)
                .Where(x => x.Processo.Code == processoCode).ToListAsync();

            return _mapper.Map<ICollection<AndamentoDTO>>(andamentos);

        }
    }
}
