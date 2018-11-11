using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.FluentMaps
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
		ToTable("Enderecos");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(a => a.CEP).IsRequired().HasColumnType("Varchar").HasColumnName("CEP");
            Property(a => a.Rua).IsRequired().HasColumnType("Varchar").HasColumnName("Logradouro");
            Property(a => a.Bairro).IsRequired().HasColumnType("Varchar").HasColumnName("Bairro");
            Property(a => a.Cidade).IsRequired().HasColumnType("Varchar").HasColumnName("Cidade");
            Property(a => a.Estado).IsRequired().HasColumnType("Varchar").HasColumnName("Estado");
			Property(a => a.Numero).IsRequired().HasColumnType("Integer").HasColumnName("Numero");
        }
    }
}