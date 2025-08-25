namespace phnds_processos.domain.Base
{
    public interface IBaseRepository<Dto> where Dto : BaseDTO 
    {
        Task<Dto?> GetByIdAsync(int id);
        Task<IEnumerable<Dto>> GetAllAsync();
        Task<Dto?> GetByCodeAsync(Guid code);
    }
}
