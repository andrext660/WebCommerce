﻿using System.ComponentModel.DataAnnotations.Schema;
using WebCommerce.Models.Classes;
using System.Data.Entity.ModelConfiguration;

namespace WebCommerce.Models.FluentMaps
{
    public class CupomMap : EntityTypeConfiguration<Cupom>
    {
        public CupomMap()
        {
            ToTable("Cupons");
            HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(a => a.DescontoQuantidade).IsRequired().HasColumnType("float").HasColumnName("DescontoQuantidade").HasParameterName("Desconto Quantidade");
            Property(a => a.DescontoPorcentagem).IsRequired().HasColumnType("int").HasColumnName("DescontoPorcentagem");
            Property(a => a.Valido).HasColumnName("Valido").HasColumnType("boolean");
            Property(a => a.Quantidade).IsRequired().HasColumnType("int").HasColumnName("Quantidade");
            Property(a => a.Descricao).HasMaxLength(30).IsRequired().HasColumnType("Varchar").HasColumnName("Descricao");



            /*HasMany(s => s.ListaCliente)
                .WithMany(a => a.ListaCupom)
                .Map(cs =>
                {
                    cs.MapLeftKey("ClienteRefId");
                    cs.MapRightKey("CupomRefId");
                    cs.ToTable("ClienteCupom");
                });*/


        }
    }
}