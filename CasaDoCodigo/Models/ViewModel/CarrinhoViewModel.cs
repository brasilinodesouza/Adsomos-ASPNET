using System.Reflection;

namespace CasaDoCodigo.Models.ViewModel
{
    public class CarrinhoViewModel
    {
        public List<ItemPedido> Itens { get; private set; }

        public decimal Total { get
            {
                return Itens.Sum(i => i.Subtotal);
            }

        }

        public CarrinhoViewModel(List<ItemPedido> itens)
        {   
            this.Itens = itens;
            
        }





    }
}
