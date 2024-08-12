using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    public class ItemPedido : BaseModel
    {
        [DataMember]
        public Pedido Pedido { get; private set; }
        [DataMember]
        public Produto Produto { get; private set; }
        [DataMember]
        public int Quantidade { get; private set; }
        [DataMember]
        public decimal PrecoUnitario { get; private set; }
        [DataMember]
        public decimal Subtotal {
            get { return Quantidade * PrecoUnitario; }
        }

        public void AtualizaQuantidade (int quantidade)
        {
            this.Quantidade = quantidade;
        }

        public ItemPedido(int id, Pedido pedido, Produto produto, int quantidade) : this(pedido, produto,quantidade)
        {
            this.Id = id;

        }

        public ItemPedido() { }
        public ItemPedido(Pedido pedido, Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
            this.PrecoUnitario = produto.Preco;
            this.Pedido = pedido;
            
        }







    }
}
