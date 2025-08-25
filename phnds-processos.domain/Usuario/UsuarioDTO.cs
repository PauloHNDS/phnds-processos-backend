namespace phnds_processos.domain.Usuario
{
    public sealed class UsuarioDTO : Base.BaseDTO
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public UsuarioTipoEnum Tipo { get; set; }
    }
}
