using phnds_processos.domain.Advogado;

namespace phnds_processos.domain.Parte
{
    public sealed class ParteDTO : Base.BaseDTO
    {
        public required string Nome { get; set; }
        public ParteTipoEnum Tipo { get; set; }
        public required ProcessoDTO Processo { get; set; }

        public required AdvogadoDTO Advogado { get; set; }
    }
}
