using phnds_processos.domain.Advogado;

namespace phnds_processos.domain.Andamento
{
    public sealed class AndamentoEntity : Base.BaseEntity
    {
        
        public required string Descricao { get; set; }

        public int ProcessoId { get; set; }

        public required ProcessoEntity Processo { get; set; }

    }
}
