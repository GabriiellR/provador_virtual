namespace ProvadorVirtual.Dominio.Models
{
    public class ProdutoImagensProvador : BaseModel
    {
        public int ProdutoId { get; set; }
        public string Imagem { get; set; } = string.Empty;
        public Produto Produto { get; set; }
    }
}
