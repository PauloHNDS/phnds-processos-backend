using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using phnds_processos.domain.Parte;

namespace phnds_processos.api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/parte")]
    public class ParteController : ControllerBase
    {

        private readonly IParteService _parteService;
        private readonly IParteRepository _parteRepository;

        public ParteController(IParteService parteService, IParteRepository parteRepository)
        {
            _parteService = parteService;
            _parteRepository = parteRepository;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> ListarPorProcesso([FromRoute] Guid code)
        {
            return Ok(await _parteRepository.ListarPeloProcesso(code));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarParte([FromBody] ParteCommand parte)
        {
            if (parte == null)
            {
                return BadRequest("Andamento não pode ser nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalido dados enviados");
            }

            await _parteService.AddAsync(parte);

            return Ok();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> ApagarParte([FromRoute] Guid code)
        {
            if (code == Guid.Empty)
            {
                return BadRequest();
            }

            await _parteService.DeleteAsync(code);

            return Ok();

        }

    }
}
