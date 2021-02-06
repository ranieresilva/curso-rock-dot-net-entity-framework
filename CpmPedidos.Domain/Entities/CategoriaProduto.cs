using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class CategoriaProduto : BaseDomain, IExibivel
    {
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}