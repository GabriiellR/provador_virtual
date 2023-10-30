namespace ProvadorVirtual.DTO.Administracao
{
    public class ProdutoDTO : BaseDTO
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Cor { get; set; } = string.Empty;
        public string Tamanho { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string Imagem { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public CategoriaDTO? Categoria { get; set; }
        public List<ProdutoImagemProvadorDTO>? ProdutoImagensProvador { get; set; }
        public List<FavoritosDTO>? Favoritos { get; set; }    
    }
}
