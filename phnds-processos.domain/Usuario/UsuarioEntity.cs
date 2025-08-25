namespace phnds_processos.domain.Usuario
{
    public class UsuarioEntity : Base.BaseEntity
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required byte[] Senha { get; set; }
        public UsuarioTipoEnum Tipo { get; set; }

    }
}
