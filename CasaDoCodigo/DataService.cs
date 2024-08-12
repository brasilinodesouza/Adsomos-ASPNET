using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModel;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly Contexto _contexto;

        public DataService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public List<ItemPedido> GetItensPedidos()
        {
            return this._contexto.ItensPedido.ToList();

        }

        public List<Produto> GetProdutos()
        {
            return this._contexto.Produtos.ToList();
        }

        public void InicializaDB()
        {
            this._contexto.Database.EnsureCreated();
            if (this._contexto.Produtos.Count() == 0)
            {
                List<Produto> produtos = new List<Produto>
                    {
                        new Produto ("Sleep not found", 59.90m),
                        new Produto ("May the code be with you", 59.90m ),
                        new Produto ("Rollback", 59.90m ),
                        new Produto ("REST", 69.90m),
                        new Produto ("Design", 69.90m ),
                        new Produto ("Vire o jogo",  69.90m ),
                        new Produto ("Test Driven",  79.90m ),
                        new Produto ("IOS",79.90m),
                        new Produto ("ANDROID", 79.90m),
                    };

                foreach (var produto in produtos)
                {
                    this._contexto.Produtos
                        .Add(produto);
                    this._contexto.ItensPedido
                        .Add(new ItemPedido( produto, 1));
                }
                this._contexto.SaveChanges();
            }

        }

        public UpdateItemPedidoResponse UpdateItemPedido(ItemPedido itemPedido)
        {
            var itemPedidoDB = 
            _contexto.ItensPedido
                .Where(i => i.Id == itemPedido.Id)
                .SingleOrDefault();
        
            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);
                _contexto.SaveChanges();
            }

            var itensPedido = _contexto.ItensPedido.ToList();

            var carrinhoViewModel = new CarrinhoViewModel(itensPedido);

            return new UpdateItemPedidoResponse(itemPedido, carrinhoViewModel);
        }
    }
}
