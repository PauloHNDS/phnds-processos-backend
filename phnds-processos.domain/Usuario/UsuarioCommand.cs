namespace phnds_processos.domain.Usuario
{
    public sealed class UsuarioCommand : Base.BaseCommand
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public UsuarioTipoEnum Tipo { get; set; }
    }
}
