namespace CpmPedido.Interface
{
    public interface IProdutoRepository
    {
        dynamic Get(string ordem);
        dynamic Search(string text, int pagina, string ordem);
        dynamic Detail(int id);
        dynamic Imagens(int id);
    }
}