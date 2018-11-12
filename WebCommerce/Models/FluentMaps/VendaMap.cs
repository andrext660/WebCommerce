using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.FluentMaps
{
    public class VendaMap : EntityTypeConfiguration<Venda>
    {
        public VendaMap()
        {
            ToTable("Vendas");
            HasKey(a => a.Id).
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Data).IsRequired().HasColumnType("datetime").HasColumnName("DataVenda");
            Property(a => a.ValorTotal).IsRequired().HasColumnName("ValorTotal");
            Property(a => a.Pago).HasColumnName("Pago");
            Property(a => a.CodCupom).HasColumnName("CodCupom");
			HasRequired(c => c.ListaProdutos).WithMany();
        }
    }
}