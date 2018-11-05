﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.FluentMaps
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Enderecos");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Logradouro).IsRequired().HasColumnType("Varchar").HasColumnName("Logradouro").HasParameterName("Logradouro").HasMaxLength(80);
            Property(a => a.Bairro).IsRequired().HasColumnType("Varchar").HasColumnName("Bairro").HasParameterName("Bairro");
            Property(a => a.CEP).IsRequired().HasColumnType("Varchar").HasColumnName("CEP").HasParameterName("CEP");
            Property(a => a.Cidade).IsRequired().HasColumnType("Varchar").HasColumnName("Cidade").HasParameterName("Cidade");
        }
    }
}