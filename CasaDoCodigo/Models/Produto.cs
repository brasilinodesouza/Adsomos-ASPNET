namespace CasaDoCodigo.Models
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        public Produto(int id, string nome, decimal preco)
        {
            this.Id = id;
            this.Nome = nome;   
            this.Preco = preco; 

        }

    }
}
