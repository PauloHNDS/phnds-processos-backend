using AutoMapper;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Parte;

namespace phnds_processos.data.ef.Repositories
{
    public class ParteRepository : BaseRepository<ParteEntity, ParteDTO>, IParteRepository
    {
        public ParteRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ICollection<ParteDTO>> ListarPeloProcesso(Guid processoCode)
        {
            var partes = await _dbSet
                .Where(x => !x.Apagado)
                .Where(x => x.Processo.Code == processoCode)
                .Include(x => x.Advogado)
                .ToListAsync();

            if(partes == null)
            {
                return [];
            }

            return _mapper.Map<ICollection<ParteDTO>>(partes);

        }
    }
}
