using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using phnds_processos.domain.Advogado;
using phnds_processos.domain.Processo;
using System.Threading.Tasks;

namespace phnds_processos.api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/processo")]
    public class ProcessoController : ControllerBase
    {
        private readonly IProcessoService _processoService;
        private readonly IProcessoRepository _processoRepository;

        public ProcessoController(IProcessoService processoService, IProcessoRepository processoRepository)
        {
            _processoService = processoService;
            _processoRepository = processoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessos()
        {

            var processos = await _processoRepository.GetAllAsync();    

            return Ok(processos);

        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetProcessoPage([FromQuery] int size = 15, [FromQuery] int page = 1, [FromQuery] string filter = "")
        {
            var processo = await _processoRepository.GetAllOfParams(size,page,filter);

            if (processo == null)
            {
                return NotFound();
            }

            return Ok(processo);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetProcessoByCode([FromRoute] Guid code)
        {
            if (code == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(await _processoRepository.GetByCodeAsync(code));

        }

        [HttpPost]
        public async Task<IActionResult> CreateProcesso([FromBody] ProcessoCommand processoCommand)
        {
            if (processoCommand == null)
            {
                return BadRequest("Processo não pode ser nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = await _processoService.AddAsync(processoCommand);

            if (result == null)
            {
                return BadRequest("Falha ao tentar cadastrar processo");
            }

            return CreatedAtAction(nameof(GetProcessos), new { id = result.Id }, result);

        }

        [HttpPut("{code}")]
        public async Task<IActionResult> AtualizarProcesso([FromBody] ProcessoCommand processoCommand, [FromRoute] Guid code)
        {
            if (processoCommand == null)
            {
                return BadRequest("Processo não pode ser nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _processoService.UpdateAsync(processoCommand, code);

            return Ok();

        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteProcesso([FromRoute] Guid code)
        {
            var existingProcesso = await _processoRepository.GetByCodeAsync(code);
            
            if (existingProcesso == null)
            {
                return NotFound();
            }

            await _processoService.DeleteAsync(code);
         
            return NoContent();
        }
    }
}
