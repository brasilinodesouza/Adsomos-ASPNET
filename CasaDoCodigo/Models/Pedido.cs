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
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, MinimumLength = 5)]
        public string? Nome { get;  set; }
        [Required]
        public string? Email { get;  set; }
        [Required]
        public string? Telefone { get;  set; }
        [Required]
        public string? Endereco { get;  set; }
        [Required]
        public string? Municipio { get;  set; }
        [Required]
        public string? Estado { get;  set; }





    }
}
