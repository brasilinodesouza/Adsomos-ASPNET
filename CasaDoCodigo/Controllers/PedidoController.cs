﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IDataService _dataService;
        public PedidoController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        public IActionResult Carrosel()
        {
            List<Produto> produtos = _dataService.GetProdutos();

            return View(produtos); 
        
        }

        public IActionResult Carrinho(int? produtoId)
        {
            if (produtoId.HasValue)
            {
             _dataService.AddItemPedido(produtoId.Value);
                
            }

            CarrinhoViewModel viewModel = GetCarrinhoViewModel();

            return View(viewModel);
        }

        private CarrinhoViewModel GetCarrinhoViewModel()
        {
            List<Produto> produtos =
                this._dataService.GetProdutos();

            var itensCarrinho = this._dataService.GetItensPedidos();

            CarrinhoViewModel viewModel = new CarrinhoViewModel(itensCarrinho);
            return viewModel;
        }

        public IActionResult Cadastro()
        {
            var pedido = _dataService.GetPedido();
            if (pedido == null)
            {
                return RedirectToAction("Carrosel");
            }
            else
            {
                return View(pedido);
                
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Resumo(Pedido cadastro)
        {
            if (ModelState.IsValid)
            {
                var pedido = _dataService.UpdateCadastro(cadastro);
                return View(pedido);

            }
            else
            {
                return RedirectToAction("Cadastro");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public UpdateItemPedidoReponse PostQuantidade([FromBody]ItemPedido input)
        {
            return _dataService.UpdateItemPedido(input);
        }
    }
}
