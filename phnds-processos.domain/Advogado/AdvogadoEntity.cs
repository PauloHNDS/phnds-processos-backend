using phnds_processos.domain.Parte;

namespace phnds_processos.domain.Advogado
{
    public sealed class AdvogadoEntity : Base.BaseEntity
    {
        public required string Nome { get; set; }
        public required string OAB { get; set; }
        public required string Email { get; set; } 
        public required string Celular { get; set; }
        public required ICollection<ParteEntity> Parte { get; set; }

    }
}
