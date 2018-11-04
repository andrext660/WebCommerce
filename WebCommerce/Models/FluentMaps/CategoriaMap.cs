using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.FluentMaps
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categorias");
            HasKey(a => a.Id).
            Property(a => a.Nome).IsRequired().HasColumnType("Varchar").HasColumnName("Nome").HasParameterName("Nome");
            Property(a => a.Descricao).HasColumnName("Descricao").HasColumnType("Varchar").HasParameterName("Descrição");
        }
    }
}