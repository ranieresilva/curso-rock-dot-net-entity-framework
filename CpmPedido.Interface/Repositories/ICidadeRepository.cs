using CpmPedidos.Domain;

namespace CpmPedido.Interface
{
    public interface ICidadeRepository
    {
        dynamic Get();
        int Criar(CidadeDTO model);
        int Alterar(CidadeDTO model);
        bool Excluir(int id);
    }
}