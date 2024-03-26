using FirstApi.Models;

namespace FirstApi.Filtros {
    public class ProdutosFiltroPreco : PaginationParameters{

        public decimal? Preco { get; set; } = default(decimal?);
        public string? Criterio { get; set; } = "Igual";
    }
}
