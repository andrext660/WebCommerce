using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.FluentMaps
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Clientes");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Nome).HasMaxLength(30).IsRequired().HasColumnType("Varchar").HasColumnName("Nome");
            Property(a => a.DataNascimento).IsRequired().HasColumnType("DateTime").HasColumnName("DataNasc");
            Property(a => a.CPF).HasMaxLength(11).IsRequired().HasColumnType("Varchar").HasColumnName("CPF").HasParameterName("CPF");
            Property(a => a.Telefone).HasMaxLength(11).IsRequired().HasColumnType("Varchar").HasColumnName("Telefone");
            //Property(a => a.IdEndereco) .IsRequired().HasColumnName("IdEndereco");
            HasRequired(a => a.Endereco);
			HasRequired(e => e.ListaVenda).WithMany();
		}
    }
}