using SaleMasterApi.Models;

namespace SaleMasterApi.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ObterTodosAsync();
        Task<Produto?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task RemoverAsync(Produto produto);
    }
}
