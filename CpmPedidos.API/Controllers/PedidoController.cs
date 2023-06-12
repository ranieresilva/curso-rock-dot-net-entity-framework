using CpmPedido.Interface;
using CpmPedidos.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : AppBaseController
    {
        public PedidoController(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        [HttpGet]
        [Route("ticket-maximo")]
        public decimal TicketMaximo()
        {
            return GetService<IPedidoRepository>().TicketMaximo();
        }

        [HttpGet]
        [Route("por-cliente")]
        public dynamic PedidosClientes()
        {
            return GetService<IPedidoRepository>().PedidosClientes();
        }

        [HttpPost]
        [Route("")]
        public string SalvarPedido(PedidoDTO pedido)
        {
            return GetService<IPedidoRepository>().SalvarPedido(pedido);
        }
    }
}