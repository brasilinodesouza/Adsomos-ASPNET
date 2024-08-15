using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;



namespace CasaDoCodigo.Models
{

    public class Pedido : BaseModel
    {
        public List<ItemPedido> Itens { get;  set; }

        public Pedido()
        {
            Itens = new List<ItemPedido>();


        }
        public void UpdateCadastro(Pedido cadastro)
        {
            this.Nome = cadastro.Nome;
            this.Email = cadastro.Email;
            this.Telefone = cadastro.Telefone;

            this.Endereco = cadastro.Endereco;
            this.Municipio = cadastro.Municipio;
            this.Estado = cadastro.Estado;

        }
        
        public string? Nome { get;  set; }
        public string? Email { get;  set; }
        public string? Telefone { get;  set; }
        public string? Endereco { get;  set; }
        public string? Municipio { get;  set; }
        public string? Estado { get;  set; }





    }
}
