namespace CpmPedidos.Domain
{
    public class ImagemProduto
    {
        public int IdImagem { get; set; }
        public virtual Imagem Imagem { get; set; }

        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
    }
}