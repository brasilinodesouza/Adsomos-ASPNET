using CasaDoCodigo;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;

namespace CasaDoCodigo
{
    public class Contexto : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        public Contexto()
        {

        }


        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {


        }
        
    }

}


    


