namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK_Obrigatorias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PreviousPassword", "UserId", "dbo.Usuario");
            DropIndex("dbo.Produto", new[] { "Estabelecimento_IdEstabelecimento" });
            DropIndex("dbo.Produto", new[] { "TipoProduto_IdTipoProduto" });
            DropIndex("dbo.ProdutoComentario", new[] { "Produto_IdProduto" });
            DropIndex("dbo.ProdutoComentario", new[] { "Usuario_Id" });
            DropIndex("dbo.EstabelecimentoComentario", new[] { "Estabelecimento_IdEstabelecimento" });
            DropIndex("dbo.EstabelecimentoComentario", new[] { "Usuaio_Id" });
            DropIndex("dbo.EstabelecimentoVoto", new[] { "Estabelecimento_IdEstabelecimento" });
            DropIndex("dbo.EstabelecimentoVoto", new[] { "Usuario_Id" });
            DropIndex("dbo.ProdutoVoto", new[] { "Produto_IdProduto" });
            DropIndex("dbo.ProdutoVoto", new[] { "Usuario_Id" });
            DropIndex("dbo.Promocao", new[] { "Estabelecimento_IdEstabelecimento" });
            DropIndex("dbo.Promocao", new[] { "Produto_IdProduto" });
            RenameColumn(table: "dbo.Produto", name: "Estabelecimento_IdEstabelecimento", newName: "IdEstabelecimento");
            RenameColumn(table: "dbo.Promocao", name: "Estabelecimento_IdEstabelecimento", newName: "IdEstabelecimento");
            RenameColumn(table: "dbo.ProdutoComentario", name: "Produto_IdProduto", newName: "IdProduto");
            RenameColumn(table: "dbo.ProdutoVoto", name: "Produto_IdProduto", newName: "IdProduto");
            RenameColumn(table: "dbo.Promocao", name: "Produto_IdProduto", newName: "IdProduto");
            RenameColumn(table: "dbo.Produto", name: "TipoProduto_IdTipoProduto", newName: "IdTipoProduto");
            RenameColumn(table: "dbo.ProdutoComentario", name: "Usuario_Id", newName: "IdUsuario");
            RenameColumn(table: "dbo.EstabelecimentoComentario", name: "Usuaio_Id", newName: "IdUsuario");
            RenameColumn(table: "dbo.EstabelecimentoVoto", name: "Usuario_Id", newName: "IdUsuario");
            RenameColumn(table: "dbo.ProdutoVoto", name: "Usuario_Id", newName: "IdUsuario");
            RenameColumn(table: "dbo.EstabelecimentoComentario", name: "Estabelecimento_IdEstabelecimento", newName: "IdEstabelecimento");
            RenameColumn(table: "dbo.EstabelecimentoVoto", name: "Estabelecimento_IdEstabelecimento", newName: "IdEstabelecimento");
            AlterColumn("dbo.Produto", "IdEstabelecimento", c => c.Int(nullable: false));
            AlterColumn("dbo.Produto", "IdTipoProduto", c => c.Int(nullable: false));
            AlterColumn("dbo.ProdutoComentario", "IdProduto", c => c.Int(nullable: false));
            AlterColumn("dbo.ProdutoComentario", "IdUsuario", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EstabelecimentoComentario", "IdEstabelecimento", c => c.Int(nullable: false));
            AlterColumn("dbo.EstabelecimentoComentario", "IdUsuario", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EstabelecimentoVoto", "IdEstabelecimento", c => c.Int(nullable: false));
            AlterColumn("dbo.EstabelecimentoVoto", "IdUsuario", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProdutoVoto", "IdProduto", c => c.Int(nullable: false));
            AlterColumn("dbo.ProdutoVoto", "IdUsuario", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Promocao", "IdEstabelecimento", c => c.Int(nullable: false));
            AlterColumn("dbo.Promocao", "IdProduto", c => c.Int(nullable: false));
            CreateIndex("dbo.EstabelecimentoComentario", "IdEstabelecimento");
            CreateIndex("dbo.EstabelecimentoComentario", "IdUsuario");
            CreateIndex("dbo.EstabelecimentoVoto", "IdEstabelecimento");
            CreateIndex("dbo.EstabelecimentoVoto", "IdUsuario");
            CreateIndex("dbo.ProdutoComentario", "IdUsuario");
            CreateIndex("dbo.ProdutoComentario", "IdProduto");
            CreateIndex("dbo.Produto", "IdTipoProduto");
            CreateIndex("dbo.Produto", "IdEstabelecimento");
            CreateIndex("dbo.ProdutoVoto", "IdUsuario");
            CreateIndex("dbo.ProdutoVoto", "IdProduto");
            CreateIndex("dbo.Promocao", "IdProduto");
            CreateIndex("dbo.Promocao", "IdEstabelecimento");
            AddForeignKey("dbo.PreviousPassword", "UserId", "dbo.Usuario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreviousPassword", "UserId", "dbo.Usuario");
            DropIndex("dbo.Promocao", new[] { "IdEstabelecimento" });
            DropIndex("dbo.Promocao", new[] { "IdProduto" });
            DropIndex("dbo.ProdutoVoto", new[] { "IdProduto" });
            DropIndex("dbo.ProdutoVoto", new[] { "IdUsuario" });
            DropIndex("dbo.Produto", new[] { "IdEstabelecimento" });
            DropIndex("dbo.Produto", new[] { "IdTipoProduto" });
            DropIndex("dbo.ProdutoComentario", new[] { "IdProduto" });
            DropIndex("dbo.ProdutoComentario", new[] { "IdUsuario" });
            DropIndex("dbo.EstabelecimentoVoto", new[] { "IdUsuario" });
            DropIndex("dbo.EstabelecimentoVoto", new[] { "IdEstabelecimento" });
            DropIndex("dbo.EstabelecimentoComentario", new[] { "IdUsuario" });
            DropIndex("dbo.EstabelecimentoComentario", new[] { "IdEstabelecimento" });
            AlterColumn("dbo.Promocao", "IdProduto", c => c.Int());
            AlterColumn("dbo.Promocao", "IdEstabelecimento", c => c.Int());
            AlterColumn("dbo.ProdutoVoto", "IdUsuario", c => c.String(maxLength: 128));
            AlterColumn("dbo.ProdutoVoto", "IdProduto", c => c.Int());
            AlterColumn("dbo.EstabelecimentoVoto", "IdUsuario", c => c.String(maxLength: 128));
            AlterColumn("dbo.EstabelecimentoVoto", "IdEstabelecimento", c => c.Int());
            AlterColumn("dbo.EstabelecimentoComentario", "IdUsuario", c => c.String(maxLength: 128));
            AlterColumn("dbo.EstabelecimentoComentario", "IdEstabelecimento", c => c.Int());
            AlterColumn("dbo.ProdutoComentario", "IdUsuario", c => c.String(maxLength: 128));
            AlterColumn("dbo.ProdutoComentario", "IdProduto", c => c.Int());
            AlterColumn("dbo.Produto", "IdTipoProduto", c => c.Int());
            AlterColumn("dbo.Produto", "IdEstabelecimento", c => c.Int());
            RenameColumn(table: "dbo.EstabelecimentoVoto", name: "IdEstabelecimento", newName: "Estabelecimento_IdEstabelecimento");
            RenameColumn(table: "dbo.EstabelecimentoComentario", name: "IdEstabelecimento", newName: "Estabelecimento_IdEstabelecimento");
            RenameColumn(table: "dbo.ProdutoVoto", name: "IdUsuario", newName: "Usuario_Id");
            RenameColumn(table: "dbo.EstabelecimentoVoto", name: "IdUsuario", newName: "Usuario_Id");
            RenameColumn(table: "dbo.EstabelecimentoComentario", name: "IdUsuario", newName: "Usuaio_Id");
            RenameColumn(table: "dbo.ProdutoComentario", name: "IdUsuario", newName: "Usuario_Id");
            RenameColumn(table: "dbo.Produto", name: "IdTipoProduto", newName: "TipoProduto_IdTipoProduto");
            RenameColumn(table: "dbo.Promocao", name: "IdProduto", newName: "Produto_IdProduto");
            RenameColumn(table: "dbo.ProdutoVoto", name: "IdProduto", newName: "Produto_IdProduto");
            RenameColumn(table: "dbo.ProdutoComentario", name: "IdProduto", newName: "Produto_IdProduto");
            RenameColumn(table: "dbo.Promocao", name: "IdEstabelecimento", newName: "Estabelecimento_IdEstabelecimento");
            RenameColumn(table: "dbo.Produto", name: "IdEstabelecimento", newName: "Estabelecimento_IdEstabelecimento");
            CreateIndex("dbo.Promocao", "Produto_IdProduto");
            CreateIndex("dbo.Promocao", "Estabelecimento_IdEstabelecimento");
            CreateIndex("dbo.ProdutoVoto", "Usuario_Id");
            CreateIndex("dbo.ProdutoVoto", "Produto_IdProduto");
            CreateIndex("dbo.EstabelecimentoVoto", "Usuario_Id");
            CreateIndex("dbo.EstabelecimentoVoto", "Estabelecimento_IdEstabelecimento");
            CreateIndex("dbo.EstabelecimentoComentario", "Usuaio_Id");
            CreateIndex("dbo.EstabelecimentoComentario", "Estabelecimento_IdEstabelecimento");
            CreateIndex("dbo.ProdutoComentario", "Usuario_Id");
            CreateIndex("dbo.ProdutoComentario", "Produto_IdProduto");
            CreateIndex("dbo.Produto", "TipoProduto_IdTipoProduto");
            CreateIndex("dbo.Produto", "Estabelecimento_IdEstabelecimento");
            AddForeignKey("dbo.PreviousPassword", "UserId", "dbo.Usuario", "Id", cascadeDelete: true);
        }
    }
}
