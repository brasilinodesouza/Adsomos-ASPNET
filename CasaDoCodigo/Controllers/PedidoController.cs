using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        List<Produto> produtos = new List<Produto>
        {
            new Produto ( 1, "Sleep not found", 59.90m),
            new Produto ( 2, "May the code be with you", 59.90m ),
            new Produto ( 3, "Rollback", 59.90m ),
            new Produto ( 4, "REST", 69.90m),
            new Produto ( 5, "Design", 69.90m ),
            new Produto ( 6, "Vire o jogo",  69.90m ),
            new Produto ( 7, "Test Driven",  79.90m ),
            new Produto ( 8, "IOS",79.90m),
            new Produto ( 9, "ANDROID", 79.90m),
        };
        public IActionResult Carrosel()
        {

            return View(produtos); 
        
        }

        public IActionResult Carrinho()
        {
            CarrinhoViewModel viewModel = GerCarrinhoViewModel();

            return View(viewModel);
        }

        private CarrinhoViewModel GerCarrinhoViewModel()
        {
            var itensCarrinho = new List<ItemPedido>
            {
                new ItemPedido(1, produtos[0], 1),
                new ItemPedido(2, produtos[6], 2),
                new ItemPedido(3, produtos[2], 3),
                new ItemPedido(6, produtos[6], 2)
            };

            CarrinhoViewModel viewModel = new CarrinhoViewModel(itensCarrinho);
            return viewModel;
        }

        public IActionResult Resumo()
        {
            CarrinhoViewModel viewModel = GerCarrinhoViewModel();

            return View(viewModel); 
        }
    }
}
