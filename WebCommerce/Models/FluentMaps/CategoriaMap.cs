using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.FluentMaps
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categorias");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Nome).HasMaxLength(30).IsRequired().HasColumnType("Varchar").HasColumnName("Nome");
            Property(a => a.Descricao).HasMaxLength(30).HasColumnName("Descricao").HasColumnType("Varchar");
			HasRequired(c => c.ListaProduto).WithMany();
        }
    }
}