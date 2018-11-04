﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.FluentMaps
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public CategoriaMap()
        {
            ToTable("Clientes");
            HasKey(a => a.Id).
            Property(a => a.Nome).IsRequired().HasColumnType("Varchar").HasColumnName("Nome").HasParameterName("Nome");
            Property(a => a.DataNascimento).IsRequired().HasColumnType("DateTime").HasColumnName("DataNasc").HasParameterName("Data de Nascimento");
            Property(a => a.Descricao).HasColumnName("Descricao").HasColumnType("Varchar").HasParameterName("Descrição");
            Property(a => a.CPF).IsRequired().HasColumnType("Varchar").HasColumnName("CPF").HasParameterName("CPF");
            Property(a => a.Telefone).IsRequired().HasColumnType("Varchar").HasColumnName("Telefone").HasParameterName("Telefone");
        }
    }
}