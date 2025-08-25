namespace phnds_processos.domain.Advogado
{
    public interface IAdvogadoRepository : Base.IBaseRepository<AdvogadoDTO>
    {
        Task<IEnumerable<AdvogadoDTO>> filter(string filter);
    }
}
