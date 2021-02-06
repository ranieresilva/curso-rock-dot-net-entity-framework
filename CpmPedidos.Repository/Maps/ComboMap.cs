using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ComboMap : BaseDomainMap<Combo>
    {
        public ComboMap() : base("tb_combo") { }

        public override void Configure(EntityTypeBuilder<Combo> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            builder.Property(x => x.IdImagem).HasColumnName("id_imagem").IsRequired();
            builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.IdImagem);

            builder
                .HasMany(x => x.Produtos)
                .WithMany(x => x.Combos)
                .UsingEntity<ProdutoCombo>(
                    x => x.HasOne(f => f.Produto).WithMany().HasForeignKey(f => f.IdProduto),
                    x => x.HasOne(f => f.Combo).WithMany().HasForeignKey(f => f.IdCombo),
                    x =>
                    {
                        x.ToTable("tb_produto_combo");

                        x.HasKey(f => new { f.IdProduto, f.IdCombo });

                        x.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
                        x.Property(x => x.IdCombo).HasColumnName("id_combo").IsRequired();
                    }
                );
        }
    }
}