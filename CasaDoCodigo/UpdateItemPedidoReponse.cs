using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModel;

namespace CasaDoCodigo
{
    public class UpdateItemPedidoReponse
    {
        public ItemPedido ItemPedido{ get;  set; }
        public CarrinhoViewModel CarrinhoViewModel { get;  set; }


        public UpdateItemPedidoReponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            this.ItemPedido = itemPedido;
            this.CarrinhoViewModel = carrinhoViewModel;

        }

    }
}
