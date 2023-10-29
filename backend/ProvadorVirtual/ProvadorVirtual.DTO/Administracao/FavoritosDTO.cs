namespace ProvadorVirtual.DTO.Administracao
{
    public class FavoritosDTO : BaseDTO
    {
        public int UsuarioId { get; set; }
        public virtual UsuarioDTO? Usuario { get; set; }
        public int ProdutoId { get; set; }
        public virtual ProdutoDTO? Produto { get; set; }
    }
}
