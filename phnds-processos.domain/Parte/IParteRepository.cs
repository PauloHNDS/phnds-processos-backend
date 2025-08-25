namespace phnds_processos.domain.Parte
{
    public interface IParteRepository : Base.IBaseRepository<ParteDTO>
    {
        Task<ICollection<ParteDTO>> ListarPeloProcesso(Guid processoCode);
    }
}
