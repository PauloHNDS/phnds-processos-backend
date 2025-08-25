namespace phnds_processos.domain.Andamento
{
    public interface IAndamentoRepository : Base.IBaseRepository<AndamentoDTO>
    {
        Task<ICollection<AndamentoDTO>> GetAndamentosProcesso(Guid processoCode);
    }
}
