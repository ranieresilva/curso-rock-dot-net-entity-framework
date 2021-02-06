using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ProdutoPedidoMap : BaseDomainMap<ProdutoPedido>
    {
        public ProdutoPedidoMap() : base("tb_produto_pedido") { }

        public override void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasPrecision(2).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();

            builder.Property(x => x.IdPedido).HasColumnName("id_pedido").IsRequired();
            builder.HasOne(x => x.Pedido).WithMany(x => x.Produtos).HasForeignKey(x => x.IdPedido);

            builder.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto);
        }
    }
}