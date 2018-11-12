using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.FluentMaps
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produtos");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Nome).IsRequired().HasColumnType("Varchar").HasColumnName("Nome");
            Property(a => a.Preco).IsRequired().HasColumnType("float").HasColumnName("Preco");
            Property(a => a.QuantidadeDisponivel).HasColumnName("QuantidadeDisponivel").HasColumnType("int");
            Property(a => a.Detalhes).IsRequired().HasColumnType("Varchar").HasColumnName("Detalhes");
            Property(a => a.IdCategoria).IsRequired().HasColumnName("IdCategoria");
            Property(a => a.IdPromocao).IsRequired().HasColumnName("IdPromocao");
            HasRequired(a => a.Categoria).WithRequiredPrincipal();
            HasRequired(a => a.Promocao).WithRequiredPrincipal();
        }
    }
}