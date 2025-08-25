using AutoMapper;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Advogado;
using phnds_processos.domain.Andamento;

namespace phnds_processos.data.ef.Services
{
    public class AndamentoService : BaseService<AndamentoEntity, AndamentoCommand>, IAndamentoService
    {
        public AndamentoService(DatabaseContext context, IMapper mapper) : base(context, mapper)    
        {
        }

        public override async Task<AndamentoEntity> AddAsync(AndamentoCommand command)
        {
            var processo = await _context.Processos.FirstOrDefaultAsync(x => x.Code == command.ProcessoCode);

            if(processo == null)
            {
                throw new Exception("não achado processo no banco de dados");
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Entity cannot be null");
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            var entity = _mapper.Map<AndamentoEntity>(command);

            entity.Processo = processo;

            entity.Code = Guid.NewGuid();

            entity.CriadoEm = DateTime.UtcNow;

            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return entity;
        }
       
    }
}
