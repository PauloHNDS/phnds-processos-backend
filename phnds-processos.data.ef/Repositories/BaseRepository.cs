using AutoMapper;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Base;

namespace phnds_processos.data.ef.Repositories
{
    public class BaseRepository<Entity,Dto > : IBaseRepository<Dto> where Dto : BaseDTO where Entity : BaseEntity
    {
        protected readonly DatabaseContext _context;

        protected readonly DbSet<Entity> _dbSet;

        protected readonly IMapper _mapper;

        public BaseRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<Dto>> GetAllAsync()
        {
            var entities = await _dbSet.Where(x => !x.Apagado)
                .Take(15)
                .OrderByDescending(x => x.CriadoEm)
                .ToListAsync();

            if (entities == null)
            {
                return Enumerable.Empty<Dto>();
            }

            var dtos = _mapper.Map<IEnumerable<Dto>>(entities);

            return dtos;
        }

        public async Task<Dto?> GetByCodeAsync(Guid code)
        {
            
            if (code == Guid.Empty) return null;

            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Code == code && !x.Apagado);

            if (entity is null) return null;

            return _mapper.Map<Dto>(entity);

        }

        public async Task<Dto?> GetByIdAsync(int id)
        {
            
            if (id <= 0) return null;
            
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.Apagado);
            
            if (entity is null) return null;
         
            return _mapper.Map<Dto>(entity);

        }
    }
}
