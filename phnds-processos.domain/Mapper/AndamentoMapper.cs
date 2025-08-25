using AutoMapper;
using phnds_processos.domain.Andamento;

namespace phnds_processos.domain.Mapper
{
    public class AndamentoMapper : BaseMapper
    {
        public AndamentoMapper()
        {
            CreateMap<AndamentoEntity, AndamentoDTO>();
            CreateMap<AndamentoCommand, AndamentoEntity>();
            CreateMap<AndamentoDTO, AndamentoEntity>()
                .ForMember(dest => dest.Processo, opt => opt.Ignore())
                .ForMember(dest => dest.ProcessoId, opt => opt.Ignore());
        }
    }
}
