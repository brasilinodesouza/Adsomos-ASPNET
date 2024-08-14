using CasaDoCodigo.Models;


namespace CasaDoCodigo
{
    public interface IDataService
    {
        void InicializaDB();
        List<Produto> GetProdutos();
        List<ItemPedido> GetItensPedidos();
        UpdateItemPedidoReponse UpdateItemPedido(ItemPedido itemPedido);
        void AddItemPedido(int produtoId);
        Pedido GetPedido();
        Pedido UpdateCadastro(Pedido cadastro);

    }


}