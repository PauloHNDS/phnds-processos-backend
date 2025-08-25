namespace phnds_processos.domain.Advogado
{
    public sealed class ProcessoCommand : Base.BaseCommand
    {
        public string? NumeroProcesso { get; set; }

        public string? Classe { get; set; }

        public string? Assunto { get; set; }

        public string? Juiz { get; set; }

        public string? Vara { get; set; }

        public DateTime InicioProcesso { get; set; }

        public string? Estado { get; set; }
    }
}
