using AutoMapper;
using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.DbContext;
using phnds_processos.domain.Usuario;
using System.Text;

namespace phnds_processos.data.ef.Repositories
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity, UsuarioDTO>, IUsuarioRepository
    {
        public UsuarioRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UsuarioDTO?> GetByLoginAndSenhaAsync(string login, string senha)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(senha);

            var entity = await _dbSet.FirstOrDefaultAsync(
                x => x.Email.ToLower().Equals(login) && x.Senha.Equals(bytes) && !x.Apagado
            );

            return _mapper.Map<UsuarioDTO?>(entity);

        }
    }
}
