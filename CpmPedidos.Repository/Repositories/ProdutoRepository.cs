using CpmPedido.Interface;
using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CpmPedidos.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private void OrdenarPorNome(IQueryable<Produto> query, string ordem)
        {
            if (string.IsNullOrEmpty(ordem) || ordem.ToUpper() == "ASC")
            {
                query = query.OrderBy(x => x.Nome);
            }
            else
            {
                query = query.OrderByDescending(x => x.Nome);
            }
        }

        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public dynamic Get(string ordem)
        {
            var queryProduto = DbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo);

            OrdenarPorNome(queryProduto, ordem);

            var queryRetorno = queryProduto
                .Select(x => new
                 {
                     x.Nome,
                     x.Preco,
                     Categoria = x.Categoria.Nome,
                     Imagens = x.Imagens.Select(i => new
                     {
                         i.Id,
                         i.Nome,
                         i.NomeArquivo
                     })
                 });

            return queryRetorno.ToList();
        }

        public dynamic Search(string text, int pagina, string ordem)
        {
            var queryProduto = DbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina);

            OrdenarPorNome(queryProduto, ordem);

            var queryRetorno = queryProduto
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.Categoria.Nome,
                    Imagens = x.Imagens.Select(i => new
                    {
                        i.Id,
                        i.Nome,
                        i.NomeArquivo
                    })
                });

            var produtos = queryRetorno.ToList();

            var quantProdutos = DbContext.Produtos
                .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Count();

            var quantPaginas = (quantProdutos / TamanhoPagina);
            if (quantPaginas < 1)
            {
                quantPaginas = 1;
            }

            return new { produtos, quantPaginas };
        }

        public dynamic Detail(int id)
        {
            return DbContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Codigo,
                    x.Descricao,
                    x.Preco,
                    Categoria = new
                    {
                        x.Categoria.Id,
                        x.Categoria.Nome
                    },
                    Imagens = x.Imagens.Select(i => new
                    {
                        i.Id,
                        i.Nome,
                        i.NomeArquivo
                    })
                })
                .FirstOrDefault();
        }

        public dynamic Imagens(int id)
        {
            return DbContext.Produtos
                .Include(x => x.Imagens)
                .Where(x => x.Ativo && x.Id == id)
                .SelectMany(x => x.Imagens, (produto, imagem) => new
                {
                    IdProduto = produto.Id,
                    imagem.Id,
                    imagem.Nome,
                    imagem.NomeArquivo
                })
                .FirstOrDefault();
        }
    }
}