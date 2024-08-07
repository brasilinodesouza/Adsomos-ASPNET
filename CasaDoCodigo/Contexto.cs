using CasaDoCodigo;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data.Entity;
using System;

namespace CasaDoCodigo
{
    public class Contexto : System.Data.Entity.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Produto>? Produtos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ItemPedido>? ItensPedido { get; set; }


        public Contexto(DbContextOptions<Contexto> options)
            : base()
        {

        }

    }

}


    


