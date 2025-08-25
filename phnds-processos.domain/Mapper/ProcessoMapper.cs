using AutoMapper;
using phnds_processos.domain.Advogado;

namespace phnds_processos.domain.Mapper
{
    public class ProcessoMapper : BaseMapper
    {
        public ProcessoMapper() { 
            CreateMap<ProcessoEntity, ProcessoDTO>();
            CreateMap<ProcessoCommand, ProcessoEntity>();
            CreateMap<ProcessoDTO, ProcessoEntity>()
                .ForMember(dest => dest.Partes, opt => opt.Ignore())
                .ForMember(dest => dest.Andamentos, opt => opt.Ignore());
        }
    }
}
