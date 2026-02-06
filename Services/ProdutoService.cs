using SaleMasterApi.Interfaces;
using SaleMasterApi.Models;

namespace SaleMasterApi.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repo;

        public ProdutoService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Produto>> ListarAsync()
            => _repo.ObterTodosAsync();

        public async Task<Produto> BuscarAsync(int id)
        {
            var produto = await _repo.ObterPorIdAsync(id);
            if (produto == null) throw new Exception("Produto não encontrado");
            return produto;
        }

        public async Task CriarAsync(Produto produto)
        {
            if (produto.Preco <= 0)
                throw new Exception("Produto não pode ter preço menor ou igual a zero");

            if (produto.Estoque < 0)
                throw new Exception("Quantidade em estoque não pode ser negativa");

            await _repo.AdicionarAsync(produto);
        }

        public async Task AtualizarAsync(int id, Produto dados)
        {
            var produto = await BuscarAsync(id);

            if (dados.Preco <= 0)
                throw new Exception("Produto não pode ter preço menor ou igual a zero");

            if (dados.Estoque < 0)
                throw new Exception("Quantidade em estoque não pode ser negativa");

            produto.Nome = dados.Nome;
            produto.Preco = dados.Preco;
            produto.Estoque = dados.Estoque;

            await _repo.AtualizarAsync(produto);
        }

        public async Task RemoverAsync(int id)
        {
            var produto = await BuscarAsync(id);
            await _repo.RemoverAsync(produto);
        }
    }
}
