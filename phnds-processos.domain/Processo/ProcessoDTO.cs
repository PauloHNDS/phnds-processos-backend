using phnds_processos.domain.Andamento;
using phnds_processos.domain.Parte;

namespace phnds_processos.domain.Advogado
{
    public sealed class ProcessoDTO : Base.BaseDTO
    {
        public required string NumeroProcesso { get; set; }

        public required string Classe { get; set; }

        public required string Assunto { get; set; }

        public required string Juiz { get; set; }

        public required string Vara { get; set; }

        public DateTime InicioProcesso { get; set; }

        public required string Estado { get; set; }

        public List<AndamentoDTO> Andamentos { get; set; }

        public List<ParteDTO> Partes { get; set; }
    }
}
