using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.FluentMaps
{
    public class VendaMap : EntityTypeConfiguration<Venda>
    {
        public VendaMap()
        {
            ToTable("Vendas");
            HasKey(a => a.Id).
            Property(a => a.Data).IsRequired().HasColumnType("datetime").HasColumnName("DataVenda");
            Property(a => a.ValorTotal).IsRequired().HasColumnName("ValorTotal");
            Property(a => a.Pago).HasColumnName("Pago");
        }
    }
}