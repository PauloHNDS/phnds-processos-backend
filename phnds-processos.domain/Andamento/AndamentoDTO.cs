using phnds_processos.domain.Advogado;

namespace phnds_processos.domain.Andamento
{
    public class AndamentoDTO : Base.BaseDTO
    {
        public required string Descricao { get; set; }

        public required ProcessoDTO Processo { get; set; }
    }
}
