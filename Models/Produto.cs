namespace SaleMasterApi.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }
        
        public Caracteristica? Caracteristica { get; set; }

        public void IncrementarEstoque(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentException("Quantidade deve ser positiva", nameof(quantidade));
            Estoque += quantidade;
        }
        public void DecrementarEstoque(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentException("Quantidade deve ser positiva", nameof(quantidade));
            if (quantidade > Estoque)
                throw new InvalidOperationException("Não é possível decrementar mais do que o estoque disponível");
            Estoque -= quantidade;
        }
    }
}
