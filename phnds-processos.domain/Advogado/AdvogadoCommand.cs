namespace phnds_processos.domain.Advogado
{
    public sealed class AdvogadoCommand : Base.BaseCommand
    {
        public string? Nome { get; set; }
        public string? OAB { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
    }
}
