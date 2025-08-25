using AutoMapper;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Advogado;
using phnds_processos.domain.Base;

namespace phnds_processos.data.ef.Repositories
{
    public class AdvogadoRepository : BaseRepository<AdvogadoEntity, AdvogadoDTO>, IAdvogadoRepository
    {
        public AdvogadoRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<AdvogadoDTO>> filter(string filter)
        {
            var advogados = await _dbSet.Where(x => !x.Apagado).Where(x => x.Nome.Contains(filter)).Take(10).ToListAsync();
            
            if(advogados == null)
            {
                return [];
            }

            return _mapper.Map<IEnumerable<AdvogadoDTO>>(advogados);


        }
    }
}
