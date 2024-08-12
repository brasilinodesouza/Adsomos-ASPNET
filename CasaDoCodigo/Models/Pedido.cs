namespace CasaDoCodigo.Models
{
    public class Pedido : BaseModel
    {
        public List<ItemPedido> itens { get; private set; }

        public Pedido()
        {
            itens = new List<ItemPedido>();
        }

    }
}
