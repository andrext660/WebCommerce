using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using WebCommerce.Models.Classes;
using WebCommerce.Models.FluentMaps;

namespace WebCommerce.Models.Fluent
{
    public class DataBaseContext : DbContext
    {


        public DataBaseContext() : base("name=DataBaseContext")
        {
          
        }
        public DbSet<Cliente> Aluno { get; set; }
        public DbSet<Cupom> Cupom { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Categoria> Categoria { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);


            //aqui está add as validacoes criadas nas classes Map;
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new CupomMap());
            modelBuilder.Configurations.Add(new VendaMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new PromocaoMap());
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }  
    }
}