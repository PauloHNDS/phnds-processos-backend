using phnds_processos.domain.Advogado;

namespace phnds_processos.domain.Parte
{
    public sealed class ParteEntity : Base.BaseEntity
    {

        public required string Nome { get; set; }

        public ParteTipoEnum Tipo { get; set; }

        public int ProcessoId { get; set; }

        public required ProcessoEntity Processo { get; set; }

        public int AdvogadoId { get; set; }

        public required AdvogadoEntity Advogado { get; set; }

    }
}
