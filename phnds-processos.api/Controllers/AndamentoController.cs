using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using phnds_processos.domain.Andamento;

namespace phnds_processos.api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/andamento")]
    public class AndamentoController : ControllerBase
    {
        private readonly IAndamentoRepository _andamentoRepository;
        private readonly IAndamentoService _andamentoService;

        public AndamentoController(IAndamentoRepository andamentoRepository, IAndamentoService andamentoService)
        {
            _andamentoRepository = andamentoRepository;
            _andamentoService = andamentoService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetAndamentos([FromRoute] Guid code)
        {
            return Ok(await _andamentoRepository.GetAndamentosProcesso(code));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAndamento([FromBody] AndamentoCommand andamento)
        {
            if(andamento == null)
            {
                return BadRequest("Andamento não pode ser nulo");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("Invalido dados enviados");
            }

            await _andamentoService.AddAsync(andamento);

            return Ok();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> ApagarAndamento([FromRoute] Guid code)
        {
            if(code == Guid.Empty)
            {
                return BadRequest();
            }

            await _andamentoService.DeleteAsync(code);

            return Ok();

        }
    }
}
