using Microsoft.IdentityModel.Tokens;
using phnds_processos.domain.Usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace phnds_processos.api.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly Dictionary<string, AuthResponse> _refreshTokens = new();

        public AuthService(JwtSettings jwtSettings, IUsuarioRepository usuarioRepository)
        {
            _jwtSettings = jwtSettings;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AuthResponse> LoginAsync(string email, string password)
        {
            var usuario = await _usuarioRepository.GetByLoginAndSenhaAsync(email, password);

            if (usuario is null)
            {
                throw new Exception("Usuário ou senha inválidos.");
            }

            var accessToken = GenerateJwtToken(usuario);

            var refreshToken = GenerateRefreshToken();

            var auth = new AuthResponse
            {
                UsuarioCode = usuario.Code.ToString(),
                UsuarioNome = usuario.Nome,
                UsuarioTipo = usuario.Tipo.ToString(),
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes)
            };

            _refreshTokens[refreshToken] = auth;

            return auth;
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            if (!_refreshTokens.ContainsKey(refreshToken))
                throw new Exception("Refresh token inválido");

            AuthResponse username = _refreshTokens[refreshToken];

            if (username is not null)
                throw new Exception("Usuário não encontrado para o refresh token fornecido");

            var usuario = await _usuarioRepository.GetByCodeAsync(Guid.Parse(username.UsuarioCode));

            var accessToken = GenerateJwtToken(usuario);

            var auth = new AuthResponse
            {
                UsuarioCode = usuario.Code.ToString(),
                UsuarioNome = usuario.Nome,
                UsuarioTipo = usuario.Tipo.ToString(),
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes)
            };

            _refreshTokens[refreshToken] = auth;

            return auth;
        }

        private string GenerateJwtToken(UsuarioDTO usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[] { 
                        new Claim(ClaimTypes.Name, usuario.Email) ,
                        new Claim(ClaimTypes.Role, usuario.Tipo.ToString()),
                        new Claim(ClaimTypes.NameIdentifier,usuario.Code.ToString())
                    }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

    }
}
