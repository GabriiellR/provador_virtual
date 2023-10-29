namespace ProvadorVirtual.Dominio.Models
{
    public class Favoritos : BaseModel
    {
        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto? Produto { get; set; }
    }
}
