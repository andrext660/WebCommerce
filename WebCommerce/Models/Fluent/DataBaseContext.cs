using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.Fluent
{
    public class DataBaseContext : DbContext
    {


        public DataBaseContext() : base("name=DataBaseContext")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);


            //Venda
            modelBuilder.Entity<Venda>().ToTable("Vendas").Property(g => g.Id);
            modelBuilder.Entity<Venda>().ToTable("Vendas").Property(g => g.Data);
            modelBuilder.Entity<Venda>().ToTable("Vendas").Property(g => g.ValorTotal);
            modelBuilder.Entity<Venda>().ToTable("Vendas").Property(g => g.Pago);

            //Venda



            //Produto
            modelBuilder.Entity<Produto>().ToTable("Produtos").Property(g => g.Nome);
            modelBuilder.Entity<Produto>().ToTable("Produtos").Property(g => g.Preco);
            modelBuilder.Entity<Produto>().ToTable("Produtos").Property(g => g.QuantidadeDisponivel);
            modelBuilder.Entity<Produto>().ToTable("Produtos").Property(g => g.Detalhes);

            //Produto



            // Relacionamento um para muitos //
            modelBuilder.Entity<Produto>().HasOne(g => g.Venda).WithMany(p => p.Produtos);


        }

      


    }
}