namespace phnds_processos.domain.Base
{
    public interface IBaseService<Entity, Command> where Entity : BaseEntity where Command : BaseCommand
    {
        Task<Entity> AddAsync(Command entity);
        Task<Entity> UpdateAsync(Command entity, Guid code);
        Task DeleteAsync(Guid code);

    }
}
