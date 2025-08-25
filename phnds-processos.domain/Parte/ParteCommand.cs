namespace phnds_processos.domain.Parte
{
    public sealed class ParteCommand : Base.BaseCommand
    {
        public string? Nome { get; set; }
        public ParteTipoEnum? Tipo { get; set; }

        public Guid ProcessoCode { get; set; }

        public Guid AdvogadoCode { get; set; }

    }
}
