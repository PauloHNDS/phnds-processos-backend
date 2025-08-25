using phnds_processos.domain.Parte;

namespace phnds_processos.domain.Advogado
{
    public sealed class AdvogadoDTO : Base.BaseDTO
    {
        public string Nome { get; set; }
        public string OAB { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

    }
}
