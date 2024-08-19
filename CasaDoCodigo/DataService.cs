using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;


namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly Contexto _contexto;
        private readonly IHttpContextAccessor _contextAccessor;
        public DataService(Contexto contexto, IHttpContextAccessor contextAccessor)
        {
            this._contexto = contexto;
            this._contextAccessor = contextAccessor;
        }


        public void AddItemPedido(int produtoId)
        {
            var produto = _contexto.Produtos
                .Where( p => p.Id == produtoId)
                .SingleOrDefault();

            if (produto != null)
            {
                int? pedidoID = GetSessisonPedidoId();

                Pedido pedido = null;

               
                if (pedidoID.HasValue)
                {
                    pedido = _contexto.Pedidos
                        .Where(p => p.Id == pedidoID.Value)
                        .SingleOrDefault();
                }

                if (pedido == null)
                {
                    pedido = new Pedido();
                }

                if (!_contexto.ItensPedido
                .Where(i =>
                    i.Pedido.Id == pedido.Id
                    && i.Produto.Id == produtoId)
                .Any())
                {
                _contexto.ItensPedido.Add(new ItemPedido(pedido, produto, 1));
                _contexto.SaveChanges();

                SetSessionPedidoId(pedido);

                }
            }
        }



        private void SetSessionPedidoId(Pedido pedido)
        {
            _contextAccessor.HttpContext
                .Session.SetInt32("pedidoId", pedido.Id);
        }

        private int? GetSessisonPedidoId()
        {
            return _contextAccessor.HttpContext
                .Session.GetInt32("pedidoId");
        }




        public List<ItemPedido> GetItensPedidos()
        {
            var pedidoId = GetSessisonPedidoId();

            var itens = this._contexto.ItensPedido
                .Where(i => i.Pedido.Id == pedidoId)
                .ToList();

            return itens;
        }

        public Pedido GetPedido()
        {
            int? pedidoId = GetSessisonPedidoId();
            return _contexto.Pedidos
                .Include(p => p.Itens)
                    .ThenInclude(p => p.Produto)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();
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
                //    this._contexto.ItensPedido
                //        .Add(new ItemPedido(produto, 1));
                }
                this._contexto.SaveChanges();
            }

        }



        public UpdateItemPedidoReponse UpdateItemPedido(ItemPedido itemPedido)
        {
            var itemPedidoDB = 
            _contexto.ItensPedido
                .Where(i => i.Id == itemPedido.Id)
                .SingleOrDefault();

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);
                if (itemPedidoDB.Quantidade == 0 )
                {
                    _contexto.ItensPedido.Remove(itemPedidoDB);
                }
                _contexto.SaveChanges();

            }

            int? pedidoId = GetSessisonPedidoId();
            var itensPedido = _contexto.ItensPedido.Where(x => x.Pedido.Id == pedidoId).ToList();

            var carrinhoViewModel = new CarrinhoViewModel(itensPedido);

            return new UpdateItemPedidoReponse( itemPedidoDB, carrinhoViewModel);
        }


        public Pedido UpdateCadastro(Pedido cadastro)
        {
            var pedido = GetPedido();
            pedido.UpdateCadastro(cadastro);
            _contexto.SaveChanges();
            return pedido;
        }
    }
}
