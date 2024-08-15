using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    public class ItemPedido : BaseModel
    {
        [DataMember]
        [Required]
        public Pedido Pedido { get;  set; }
        [DataMember]
        [Required]
        public Produto Produto { get;  set; }
        [DataMember]
        public int Quantidade { get;  set; }
        [DataMember]
        public decimal PrecoUnitario { get;  set; }
        [DataMember]
        public decimal Subtotal {
            get { return Quantidade * PrecoUnitario; }
        }

        

        public ItemPedido(int id, Pedido pedido ,Produto produto, int quantidade) : this(pedido, produto, quantidade)
        {
            this.Id = id;

        }

        public ItemPedido() { }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade)
        {
            this.Pedido = pedido;
            this.Produto = produto;
            this.Quantidade = quantidade;
            this.PrecoUnitario = produto.Preco;

        }

        public  void AtualizaQuantidade (int quantidade)
        {
            this.Quantidade = quantidade;
        }





    }
}
