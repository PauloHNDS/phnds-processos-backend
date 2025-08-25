using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using phnds_processos.domain.Advogado;

namespace phnds_processos.api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/advogado")]
    public class AdvogadoController : ControllerBase
    {
        private readonly IAdvogadoService _advogadoService;
        private readonly IAdvogadoRepository _advogadoRepository;

        public AdvogadoController(
            IAdvogadoService advogadoService,
            IAdvogadoRepository advogadoRepository)
        {
            _advogadoService = advogadoService;
            _advogadoRepository = advogadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdvogados()
        {
            var advogados = await _advogadoRepository.GetAllAsync();
            return Ok(advogados);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> filterAdvogados([FromQuery] string filter)
        {
            return Ok(await this._advogadoRepository.filter(filter));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAdvogado([FromBody] AdvogadoCommand advogado)
        {
            if (advogado == null)
            {
                return BadRequest("Advogado não pode ser nulo");
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalido dados enviados");
            }
            
            await _advogadoService.AddAsync(advogado);
        
            return Ok();
        
        }

    }
}
