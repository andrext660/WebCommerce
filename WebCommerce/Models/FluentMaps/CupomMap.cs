using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.FluentMaps
{
    public class CupomMap : EntityTypeConfiguration<Cupom>
    {
        public CupomMap()
        {
            ToTable("Cupons");
            HasKey(a => a.Codigo).
            Property(a => a.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.DescontoQuantidade).IsRequired().HasColumnType("float").HasColumnName("DescontoQuantidade").HasParameterName("Desconto Quantidade");
            Property(a => a.DescontoPorcentagem).IsRequired().HasColumnType("int").HasColumnName("DescontoPorcentagem").HasParameterName("Desconto Porcentagem");
            Property(a => a.Valido).HasColumnName("Valido").HasColumnType("boolean").HasParameterName("Válido");
            Property(a => a.Quantidade).IsRequired().HasColumnType("int").HasColumnName("Quantidade").HasParameterName("Quantidade");
            Property(a => a.Descricao).IsRequired().HasColumnType("Varchar").HasColumnName("Descricao").HasParameterName("Descricao");
            
            HasRequired(c => c.ListaCupom).WithMany();
        }
    }
}