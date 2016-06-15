namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produtos_Estabelecimento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estabelecimento_Produto", "IdProduto", "dbo.Estabelecimento");
            DropForeignKey("dbo.Estabelecimento_Produto", "IdEstabelecimento", "dbo.Produto");
            DropIndex("dbo.Estabelecimento_Produto", new[] { "IdProduto" });
            DropIndex("dbo.Estabelecimento_Produto", new[] { "IdEstabelecimento" });
            AddColumn("dbo.Produto", "Estabelecimento_IdEstabelecimento", c => c.Int());
            CreateIndex("dbo.Produto", "Estabelecimento_IdEstabelecimento");
            AddForeignKey("dbo.Produto", "Estabelecimento_IdEstabelecimento", "dbo.Estabelecimento", "IdEstabelecimento");
            DropTable("dbo.Estabelecimento_Produto");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Estabelecimento_Produto",
                c => new
                    {
                        IdProduto = c.Int(nullable: false),
                        IdEstabelecimento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdProduto, t.IdEstabelecimento });
            
            DropForeignKey("dbo.Produto", "Estabelecimento_IdEstabelecimento", "dbo.Estabelecimento");
            DropIndex("dbo.Produto", new[] { "Estabelecimento_IdEstabelecimento" });
            DropColumn("dbo.Produto", "Estabelecimento_IdEstabelecimento");
            CreateIndex("dbo.Estabelecimento_Produto", "IdEstabelecimento");
            CreateIndex("dbo.Estabelecimento_Produto", "IdProduto");
            AddForeignKey("dbo.Estabelecimento_Produto", "IdEstabelecimento", "dbo.Produto", "IdProduto", cascadeDelete: true);
            AddForeignKey("dbo.Estabelecimento_Produto", "IdProduto", "dbo.Estabelecimento", "IdEstabelecimento", cascadeDelete: true);
        }
    }
}
