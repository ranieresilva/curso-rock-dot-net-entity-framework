namespace CpmPedidos.Domain
{
    public class ProdutoCombo
    {
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        public int IdCombo { get; set; }
        public virtual Combo Combo { get; set; }
    }
}