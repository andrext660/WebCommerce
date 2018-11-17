namespace WebCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        CPF = c.String(),
                        Telefone = c.String(),
                        Endereco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CEP = c.String(),
                        Rua = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cupoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescontoPorcentagem = c.Int(nullable: false),
                        Valido = c.Boolean(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Descricao = c.String(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        ValorTotal = c.Single(nullable: false),
                        Pago = c.Boolean(nullable: false),
                        CodCupom = c.Int(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        Cupom_Id = c.Int(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cupoms", t => t.Cupom_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cupom_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Single(nullable: false),
                        QuantidadeDisponivel = c.Int(nullable: false),
                        Detalhes = c.String(),
                        IdCategoria = c.Int(),
                        IdPromocao = c.Int(),
                        Categoria_Id = c.Int(),
                        Promocao_Id = c.Int(),
                        Venda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .ForeignKey("dbo.Promocaos", t => t.Promocao_Id)
                .ForeignKey("dbo.Vendas", t => t.Venda_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Promocao_Id)
                .Index(t => t.Venda_Id);
            
            CreateTable(
                "dbo.Promocaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescontoPorcentagem = c.Int(nullable: false),
                        DataPrazo = c.DateTime(nullable: false),
                        Valido = c.Boolean(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Vendas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Produtoes", "Venda_Id", "dbo.Vendas");
            DropForeignKey("dbo.Produtoes", "Promocao_Id", "dbo.Promocaos");
            DropForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Vendas", "Cupom_Id", "dbo.Cupoms");
            DropForeignKey("dbo.Cupoms", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Endereco_Id", "dbo.Enderecoes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Produtoes", new[] { "Venda_Id" });
            DropIndex("dbo.Produtoes", new[] { "Promocao_Id" });
            DropIndex("dbo.Produtoes", new[] { "Categoria_Id" });
            DropIndex("dbo.Vendas", new[] { "Cliente_Id" });
            DropIndex("dbo.Vendas", new[] { "Cupom_Id" });
            DropIndex("dbo.Cupoms", new[] { "Cliente_Id" });
            DropIndex("dbo.Clientes", new[] { "Endereco_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Promocaos");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Vendas");
            DropTable("dbo.Cupoms");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
