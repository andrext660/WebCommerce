namespace WebCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Cliente_Id");
            AddForeignKey("dbo.AspNetUsers", "Cliente_Id", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.AspNetUsers", new[] { "Cliente_Id" });
            DropColumn("dbo.AspNetUsers", "Cliente_Id");
        }
    }
}
