namespace CpmPedidos.Domain
{
    public class Cidade : BaseDomain, IExibivel
    {
        public string Nome { get; set; }
        public string Uf { get; set; }

        public bool Ativo { get; set; }
    }
}