using CpmPedido.Interface;
using CpmPedidos.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : AppBaseController
    {
        public CidadeController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        public dynamic Get()
        {
            return GetService<ICidadeRepository>().Get();
        }

        [HttpPost]
        public int Criar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Criar(model);
        }

        [HttpPut]
        public int Alterar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Alterar(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Excluir(int id)
        {
            return GetService<ICidadeRepository>().Excluir(id);
        }
    }
}