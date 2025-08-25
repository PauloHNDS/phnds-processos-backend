using AutoMapper;
using phnds_processos.domain.Advogado;

namespace phnds_processos.domain.Mapper
{
    public class AdvogadoMapper : BaseMapper
    {
        public AdvogadoMapper()
        {
            CreateMap<AdvogadoEntity, AdvogadoDTO>();
            CreateMap<AdvogadoCommand, AdvogadoEntity>();
            CreateMap<AdvogadoDTO, AdvogadoEntity>()
                .ForMember(dest => dest.Parte, opt => opt.Ignore());
        }
    }
}
