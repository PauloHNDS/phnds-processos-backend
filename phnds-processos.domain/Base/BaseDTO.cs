namespace phnds_processos.domain.Base
{
    public abstract class BaseDTO
    {
        public Guid Code { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime AtualizadoEm { get; set; }

        public DateTime ApagadoEm { get; set; }

        public bool Apagado { get; set; }
    }
}
