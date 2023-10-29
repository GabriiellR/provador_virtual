namespace ProvadorVirtual.DTO.Administracao
{
    public class ProdutoImagemProvadorDTO : BaseDTO
    {
        public int ProdutoId { get; set; }
        public string Imagem { get; set; } = string.Empty;
        public ProdutoDTO Produto { get; set; }
    }
}
