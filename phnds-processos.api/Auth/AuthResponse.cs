namespace phnds_processos.api.Auth
{
    public class AuthResponse
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public string UsuarioCode { get; set; } = null!;
        public string UsuarioNome { get; set; } = null!;
        public string UsuarioTipo { get; set; }
        public DateTime Expiration { get; set; }
    }
}
