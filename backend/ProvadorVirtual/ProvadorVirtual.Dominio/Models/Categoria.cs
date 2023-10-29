namespace ProvadorVirtual.Dominio.Models
{
    public class Categoria : BaseModel
    {
        public string Nome { get; set; } = string.Empty;
        public virtual List<Produto>? Produtos { get; set; }
    }
}
