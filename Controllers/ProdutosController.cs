using Microsoft.AspNetCore.Mvc;
using SaleMasterApi.Models;
using SaleMasterApi.Services;

namespace SaleMasterApi.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
            => Ok(await _service.ListarAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscar(int id)
            => Ok(await _service.BuscarAsync(id));

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Produto produto)
        {
            await _service.CriarAsync(produto);
            return CreatedAtAction(nameof(Buscar), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produto)
        {
            await _service.AtualizarAsync(id, produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }
}
