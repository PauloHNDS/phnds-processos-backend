using AutoMapper;
using phnds_processos.domain.Parte;

namespace phnds_processos.domain.Mapper
{
    public class ParteMapper : BaseMapper
    {
        public ParteMapper()
        {
            CreateMap<ParteEntity, ParteDTO>();
            CreateMap<ParteCommand, ParteEntity>();
            CreateMap<ParteDTO, ParteEntity>()
                .ForMember(dest => dest.Processo, opt => opt.Ignore())
                .ForMember(dest => dest.ProcessoId, opt => opt.Ignore())
                .ForMember(dest => dest.Advogado, opt => opt.Ignore());
        }
    }
}
