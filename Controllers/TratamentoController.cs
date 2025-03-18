using Microsoft.AspNetCore.Mvc;
using OdontoPrevAPI.Models;
using OdontoPrevAPI.Repositories;
using OdontoPrevAPI.Data;

namespace OdontoPrevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamentoController : ControllerBase
    {
        private readonly TratamentoRepository _repository;

        public TratamentoController(OdontoPrevContext context)
        {
            _repository = new TratamentoRepository(context);
        }

        /// <summary>
        /// Obtém todos os tratamentos cadastrados.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tratamento>>> Get()
        {
            return Ok(await _repository.GetAll());
        }

        /// <summary>
        /// Obtém um tratamento pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Tratamento>> Get(int id)
        {
            var tratamento = await _repository.GetById(id);
            if (tratamento == null)
                return NotFound($"Tratamento {id} não encontrado.");

            return Ok(tratamento);
        }

        /// <summary>
        /// Cadastra um novo tratamento.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tratamento tratamento)
        {
            if (tratamento == null)
                return BadRequest("Os dados do tratamento são obrigatórios.");

            await _repository.Add(tratamento);
            return CreatedAtAction(nameof(Get), new { id = tratamento.Id }, tratamento);
        }

        /// <summary>
        /// Exclui um tratamento pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tratamento = await _repository.GetById(id);
            if (tratamento == null)
                return NotFound($"Tratamento {id} não encontrado.");

            await _repository.Delete(id);
            return NoContent();
        }
    }
}
