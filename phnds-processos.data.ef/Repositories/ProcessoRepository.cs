using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Advogado;
using phnds_processos.domain.Processo;
using phnds_processos.domain.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace phnds_processos.data.ef.Repositories
{
    public class ProcessoRepository : BaseRepository<ProcessoEntity, ProcessoDTO>, IProcessoRepository
    {
        public ProcessoRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<IEnumerable<ProcessoEntity>> GetByNumeroProcessoAsync(string numeroProcesso)
        {
            return await _dbSet
                .Where(x => x.NumeroProcesso == numeroProcesso && !x.Apagado)
                .ToListAsync();
        }
        public async Task<IEnumerable<ProcessoEntity>> GetByEstadoAsync(string estado)
        {
            return await _dbSet
                .Where(x => x.Estado == estado && !x.Apagado)
                .ToListAsync();
        }

        public async Task<ResponseDto<ProcessoDTO>> GetAllOfParams(int size, int page, string filter)
        {
            if(page <= 0)
            {
                page = 1;
            }

            if(size <= 0)
            {
                size = 1;
            }

            var totalItems = await _dbSet
                .Where(x => !x.Apagado)
                .Where(
                    x =>
                    x.NumeroProcesso.Contains(filter) ||
                    x.Classe.Contains(filter) ||
                    x.Assunto.Contains(filter) ||
                    x.Juiz.Contains(filter) ||
                    x.Vara.Contains(filter) ||
                    x.Estado.Contains(filter)
                ).CountAsync();

            var itens = await _dbSet
                .Where(x => !x.Apagado)
                .Where(
                    x =>
                    x.NumeroProcesso.Contains(filter) ||
                    x.Classe.Contains(filter) ||
                    x.Assunto.Contains(filter) ||
                    x.Juiz.Contains(filter) ||
                    x.Vara.Contains(filter) || 
                    x.Estado.Contains(filter) 
                )
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            if(itens == null || !itens.Any())
            {
                return new ResponseDto<ProcessoDTO>
                {
                    Items = Enumerable.Empty<ProcessoDTO>(),
                    TotalItems = 0,
                    PageNumber = page,
                    PageSize = size
                };
            }

            var itensDto = _mapper.Map<IEnumerable<ProcessoDTO>>(itens);

            return new ResponseDto<ProcessoDTO>
            {
                Items = itensDto,
                TotalItems = totalItems,
                PageNumber = page,
                PageSize = size
            };

        }
    }
}
