namespace ProvadorVirtual.Dominio.Models
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Cor { get; set; } = string.Empty;
        public string Tamanho { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string Imagem { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public string ImagemGravataProvador { get; set; } = string.Empty;

        public virtual List<Favoritos>? Favoritos { get; set; }
        public virtual List<ProdutoImagensProvador>? ProdutoImagensProvador{ get; set; }
    }
}
