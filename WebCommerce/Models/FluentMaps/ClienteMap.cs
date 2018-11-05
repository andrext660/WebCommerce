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
            Property(a => a.Nome).IsRequired().HasColumnType("Varchar").HasColumnName("Nome").HasParameterName("Nome");
            Property(a => a.DataNascimento).IsRequired().HasColumnType("DateTime").HasColumnName("DataNasc").HasParameterName("Data de Nascimento");
            Property(a => a.CPF).IsRequired().HasColumnType("Varchar").HasColumnName("CPF").HasParameterName("CPF");
            Property(a => a.Telefone).IsRequired().HasColumnType("Varchar").HasColumnName("Telefone").HasParameterName("Telefone");
            Property(a => a.IdEndereco).IsRequired().HasColumnName("Endereco");

            HasRequired(a => a.Endereco).WithRequiredPrincipal();
        }
    }
}