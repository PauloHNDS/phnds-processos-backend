using phnds_processos.domain.Advogado;

namespace phnds_processos.domain.Andamento
{
    public class AndamentoCommand : Base.BaseCommand
    {
        public string? Descricao { get; set; }

        public Guid ProcessoCode { get; set; }

    }
}
