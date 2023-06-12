using CpmPedidos.Domain;

namespace CpmPedido.Interface
{
    public interface IPedidoRepository
    {
        decimal TicketMaximo();
        dynamic PedidosClientes();
        string SalvarPedido(PedidoDTO pedido);
    }
}