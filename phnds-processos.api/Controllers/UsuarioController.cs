using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using phnds_processos.domain.Usuario;
using System.Threading.Tasks;

namespace phnds_processos.api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;

        private readonly IUsuarioService _usuarioService;

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IMapper _mapper;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {

            var usuarios = await _usuarioRepository.GetAllAsync();

            return Ok(usuarios);

        }

        [HttpGet("{code}")]
        public async Task<IActionResult> ObterUsuarioPorCode(Guid code)
        {
            var usuario = await _usuarioRepository.GetByCodeAsync(code);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);

        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCommand usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _usuarioService.AddAsync(usuario);

            return CreatedAtAction(
                nameof(ObterUsuarioPorCode),
                new { code = createdUser.Code }
            );

        }

        [HttpPut("{code}")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioCommand usuario, [FromRoute] Guid code)
        {
            if (usuario == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedUser = await _usuarioService.UpdateAsync(usuario, code);

            return Ok(updatedUser);

        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] Guid code)
        {
            if (code == Guid.Empty)
            {
                return NotFound();
            }

            await _usuarioService.DeleteAsync(code);

            _logger.LogInformation($"Usuário com code {code} foi deletado com sucesso.");

            return NoContent();

        }
    }
}
