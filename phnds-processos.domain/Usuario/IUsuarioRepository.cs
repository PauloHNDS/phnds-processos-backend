namespace phnds_processos.domain.Usuario
{
    public interface IUsuarioRepository : Base.IBaseRepository<UsuarioDTO>
    {
        Task<UsuarioDTO?> GetByLoginAndSenhaAsync(string login, string senha);
    }
}
