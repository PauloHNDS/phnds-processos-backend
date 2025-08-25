namespace phnds_processos.domain.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public Guid Code { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime? AtualizadoEm { get; set; } 

        public DateTime? ApagadoEm { get; set; }

        public bool Apagado { get; set; } = false;
    }
}
