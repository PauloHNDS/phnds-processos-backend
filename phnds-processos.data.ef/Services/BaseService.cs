using AutoMapper;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Base;
using System.Threading.Tasks;

namespace phnds_processos.data.ef.Services
{
    public class BaseService<Entity, Command> : IBaseService<Entity, Command> 
        where Entity : BaseEntity
        where Command : BaseCommand
    {

        protected readonly DatabaseContext _context;

        protected readonly DbSet<Entity> _dbSet;

        protected readonly IMapper _mapper;
        public BaseService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
            _mapper = mapper;
        }
        public  virtual async  Task<Entity> AddAsync(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Entity cannot be null");
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            var entity = _mapper.Map<Entity>(command);

            entity.Code = Guid.NewGuid();

            entity.CriadoEm = DateTime.UtcNow;

            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid code)
        {
            if (code == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Entity), "codigo não pode ser nulo");
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Code == code && !x.Apagado);

            if (entity == null)
            {
                throw new KeyNotFoundException($"A entidade com o código : {code} não foi encontrado.");
            }

            entity.Apagado = true;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

        }

        public async Task<Entity> UpdateAsync(Command command, Guid code)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Entidade não pode se nula !!!");
            }

            var existingEntity = await _dbSet.FirstOrDefaultAsync(x => x.Code == code && !x.Apagado);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"A entidade com o código : {code} não foi encontrado.");
            }

            var entity = _mapper.Map<Entity>(command);

            entity.Id = existingEntity.Id;

            entity.Code = existingEntity.Code;

            entity.CriadoEm = existingEntity.CriadoEm;

            await _context.Database.BeginTransactionAsync();

            _dbSet.Update(entity);

            await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            return entity;
        }
    }
}
