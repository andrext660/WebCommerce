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
        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Cliente> Aluno { get; set; }
        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Cupom> Cupom { get; set; }
        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Estado> Estado { get; set; }
        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Produto> Produto { get; set; }
        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Endereco> Endereco { get; set; }
        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Promocao> Promocao { get; set; }
        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Venda> Venda { get; set; }
        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Categoria> Categoria { get; set; }


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