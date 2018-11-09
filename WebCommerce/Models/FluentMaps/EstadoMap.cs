using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.FluentMaps
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("Estados");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Nome).IsRequired().HasColumnType("Varchar").HasColumnName("Nome").HasParameterName("Nome");
            Property(a => a.Sigla).IsRequired().HasColumnType("Varchar").HasColumnName("Sigla").HasParameterName("Sigla");
			//HasRequired(e => e.ListaEndereco).WithMany();
		}
    }
}