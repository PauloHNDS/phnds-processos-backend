using AutoMapper;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Advogado;
using phnds_processos.domain.Parte;

namespace phnds_processos.data.ef.Services
{
    public class ParteService : BaseService<ParteEntity, ParteCommand>, IParteService
    {
        public ParteService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ParteEntity> AddAsync(ParteCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Entity cannot be null");
            }

            var processo = await _context.Processos.FirstOrDefaultAsync(x => x.Code == command.ProcessoCode);

            if(processo == null)
            {
                throw new ArgumentNullException("Processo não encontrado na base de dados");
            }

            var advogado = await _context.Advogados.FirstOrDefaultAsync(x => x.Code == command.AdvogadoCode);

            if (advogado == null)
            {
                throw new ArgumentNullException("Advogado não encontrado na base de dados");
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            var entity = _mapper.Map<ParteEntity>(command);

            entity.Code = Guid.NewGuid();

            entity.CriadoEm = DateTime.UtcNow;

            entity.Advogado = advogado;

            entity.Processo = processo;

            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return entity;
        }
    }
}
