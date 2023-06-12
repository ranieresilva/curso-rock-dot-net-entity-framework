using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class PedidoDTO
    {
        public int IdCliente { get; set; }
        public List<ProdutoPedidoDTO> Produtos { get; set; }
    }
}