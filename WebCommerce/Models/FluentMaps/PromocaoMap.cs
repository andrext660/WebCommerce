using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.FluentMaps
{
    public class PromocaoMap : EntityTypeConfiguration<Promocao>
    {
        public PromocaoMap()
        {
            ToTable("Promocoes");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.DescontoPorcentagem).IsRequired().HasColumnType("int").HasColumnName("DescontoPorcentagem").HasParameterName("Desconto Porcentagem");
            Property(a => a.DescontoQuantidade).IsRequired().HasColumnType("int").HasColumnName("DescontoQuantidade").HasParameterName("Desconto Quantidade");
            Property(a => a.DataPrazo).IsRequired().HasColumnType("DateTime").HasColumnName("DataPrazo").HasParameterName("Data Prazo");
            Property(a => a.Valido).HasColumnName("Valido").HasColumnType("Boolean").HasParameterName("Válido");
            Property(a => a.Descricao).HasColumnName("Descricao").HasColumnType("Varchar").HasParameterName("Descrição");
        }
    }
}