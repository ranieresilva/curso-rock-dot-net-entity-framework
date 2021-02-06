namespace CpmPedido.Interface
{
    public interface IPedidoRepository
    {
        decimal TicketMaximo();
        dynamic PedidosClientes();
    }
}