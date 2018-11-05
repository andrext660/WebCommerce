using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.FluentMaps
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produtos");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Nome).IsRequired().HasColumnType("Varchar").HasColumnName("Nome").HasParameterName("Nome").HasMaxLength(80);
            Property(a => a.Preco).IsRequired().HasColumnType("float").HasColumnName("Preco").HasParameterName("Preco");
            Property(a => a.QuantidadeDisponivel).HasColumnName("QuantidadeDisponivel").HasColumnType("int").HasParameterName("Quantidade Disponivel");
            Property(a => a.Detalhes).IsRequired().HasColumnType("Varchar").HasColumnName("Detalhes").HasParameterName("Detalhes");
        }
    }
}