using AutoMapper;
using phnds_processos.domain.Usuario;

namespace phnds_processos.domain.Mapper
{
    public class UsuarioMapper : BaseMapper
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioEntity, UsuarioDTO>();
            CreateMap<UsuarioCommand, UsuarioEntity>();
            CreateMap<UsuarioDTO, UsuarioEntity>();
        }
    }
}
