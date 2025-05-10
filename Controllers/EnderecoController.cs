using Microsoft.AspNetCore.Mvc;
using OdontoPrevAPI.Dtos;
using OdontoPrevAPI.Services;

namespace OdontoPrevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly ViaCepService _viaCepService;

        public EnderecoController(ViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }

        /// <summary>
        /// Consulta o endereço com base no CEP informado.
        /// </summary>
        /// <param name="cep">CEP no formato 00000000</param>
        /// <returns>Endereço completo ou erro se não encontrado</returns>
        [HttpGet("{cep}")]
        public async Task<ActionResult<EnderecoResponse>> Get(string cep)
        {
            var endereco = await _viaCepService.ObterEnderecoPorCep(cep);

            if (endereco == null || endereco.Cep == null)
                return NotFound("CEP não encontrado.");

            return Ok(endereco);
        }
    }
}
