using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    public class Produto : BaseModel
    {
        
        [DataMember]
        public string Nome { get;  set; }
        [DataMember]
        public decimal Preco { get;  set; }

        public Produto()
        {
            
        }
        public Produto(int id, string nome, decimal preco) : this(nome, preco)
        {
            this.Id = id;

        }
        public Produto(string nome, decimal preco)
        {
            this.Nome = nome;   
            this.Preco = preco; 
            
        }
    }
}
