namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estabelecimento",
                c => new
                    {
                        IdEstabelecimento = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(maxLength: 200),
                        Localizacao = c.String(maxLength: 200),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.IdEstabelecimento);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        IdProduto = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(maxLength: 200),
                        Preco = c.Decimal(nullable: false, storeType: "money"),
                        Foto = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        TipoProduto_IdTipoProduto = c.Int(),
                    })
                .PrimaryKey(t => t.IdProduto)
                .ForeignKey("dbo.TipoProduto", t => t.TipoProduto_IdTipoProduto)
                .Index(t => t.TipoProduto_IdTipoProduto);
            
            CreateTable(
                "dbo.ProdutoComentario",
                c => new
                    {
                        IdProdutoComentario = c.Int(nullable: false, identity: true),
                        Comentario = c.String(nullable: false, maxLength: 4000),
                        Produto_IdProduto = c.Int(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdProdutoComentario)
                .ForeignKey("dbo.Produto", t => t.Produto_IdProduto)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Produto_IdProduto)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Foto = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        Senha = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Usuario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.EstabelecimentoComentario",
                c => new
                    {
                        IdEstabelecimentoComentario = c.Int(nullable: false, identity: true),
                        Comentario = c.String(nullable: false, maxLength: 4000),
                        Estabelecimento_IdEstabelecimento = c.Int(),
                        Usuaio_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdEstabelecimentoComentario)
                .ForeignKey("dbo.Estabelecimento", t => t.Estabelecimento_IdEstabelecimento)
                .ForeignKey("dbo.Usuario", t => t.Usuaio_Id)
                .Index(t => t.Estabelecimento_IdEstabelecimento)
                .Index(t => t.Usuaio_Id);
            
            CreateTable(
                "dbo.EstabelecimentoVoto",
                c => new
                    {
                        IdEstabelecimentoVoto = c.Int(nullable: false, identity: true),
                        Pontos = c.Int(nullable: false),
                        Estabelecimento_IdEstabelecimento = c.Int(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdEstabelecimentoVoto)
                .ForeignKey("dbo.Estabelecimento", t => t.Estabelecimento_IdEstabelecimento)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Estabelecimento_IdEstabelecimento)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.UsuarioLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.PreviousPassword",
                c => new
                    {
                        PasswordHash = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => new { t.PasswordHash, t.UserId })
                .ForeignKey("dbo.Usuario", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProdutoVoto",
                c => new
                    {
                        IdPodutoVoto = c.Int(nullable: false, identity: true),
                        Pontos = c.Int(nullable: false),
                        Produto_IdProduto = c.Int(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdPodutoVoto)
                .ForeignKey("dbo.Produto", t => t.Produto_IdProduto)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Produto_IdProduto)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.UsuarioPerfil",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Usuario_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .ForeignKey("dbo.Perfil", t => t.IdentityRole_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Promocao",
                c => new
                    {
                        IdPromocao = c.Int(nullable: false, identity: true),
                        Preco = c.Decimal(nullable: false, storeType: "money"),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Ativa = c.Boolean(nullable: false),
                        Estabelecimento_IdEstabelecimento = c.Int(),
                        Produto_IdProduto = c.Int(),
                    })
                .PrimaryKey(t => t.IdPromocao)
                .ForeignKey("dbo.Estabelecimento", t => t.Estabelecimento_IdEstabelecimento)
                .ForeignKey("dbo.Produto", t => t.Produto_IdProduto)
                .Index(t => t.Estabelecimento_IdEstabelecimento)
                .Index(t => t.Produto_IdProduto);
            
            CreateTable(
                "dbo.TipoProduto",
                c => new
                    {
                        IdTipoProduto = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.IdTipoProduto);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Estabelecimento_Produto",
                c => new
                    {
                        IdProduto = c.Int(nullable: false),
                        IdEstabelecimento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdProduto, t.IdEstabelecimento })
                .ForeignKey("dbo.Estabelecimento", t => t.IdProduto, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.IdEstabelecimento, cascadeDelete: true)
                .Index(t => t.IdProduto)
                .Index(t => t.IdEstabelecimento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioPerfil", "IdentityRole_Id", "dbo.Perfil");
            DropForeignKey("dbo.Estabelecimento_Produto", "IdEstabelecimento", "dbo.Produto");
            DropForeignKey("dbo.Estabelecimento_Produto", "IdProduto", "dbo.Estabelecimento");
            DropForeignKey("dbo.Produto", "TipoProduto_IdTipoProduto", "dbo.TipoProduto");
            DropForeignKey("dbo.Promocao", "Produto_IdProduto", "dbo.Produto");
            DropForeignKey("dbo.Promocao", "Estabelecimento_IdEstabelecimento", "dbo.Estabelecimento");
            DropForeignKey("dbo.UsuarioPerfil", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.ProdutoVoto", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.ProdutoVoto", "Produto_IdProduto", "dbo.Produto");
            DropForeignKey("dbo.ProdutoComentario", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.PreviousPassword", "UserId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioLogin", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.EstabelecimentoVoto", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.EstabelecimentoVoto", "Estabelecimento_IdEstabelecimento", "dbo.Estabelecimento");
            DropForeignKey("dbo.EstabelecimentoComentario", "Usuaio_Id", "dbo.Usuario");
            DropForeignKey("dbo.EstabelecimentoComentario", "Estabelecimento_IdEstabelecimento", "dbo.Estabelecimento");
            DropForeignKey("dbo.UsuarioClaim", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.ProdutoComentario", "Produto_IdProduto", "dbo.Produto");
            DropIndex("dbo.Estabelecimento_Produto", new[] { "IdEstabelecimento" });
            DropIndex("dbo.Estabelecimento_Produto", new[] { "IdProduto" });
            DropIndex("dbo.Promocao", new[] { "Produto_IdProduto" });
            DropIndex("dbo.Promocao", new[] { "Estabelecimento_IdEstabelecimento" });
            DropIndex("dbo.UsuarioPerfil", new[] { "IdentityRole_Id" });
            DropIndex("dbo.UsuarioPerfil", new[] { "Usuario_Id" });
            DropIndex("dbo.ProdutoVoto", new[] { "Usuario_Id" });
            DropIndex("dbo.ProdutoVoto", new[] { "Produto_IdProduto" });
            DropIndex("dbo.PreviousPassword", new[] { "UserId" });
            DropIndex("dbo.UsuarioLogin", new[] { "Usuario_Id" });
            DropIndex("dbo.EstabelecimentoVoto", new[] { "Usuario_Id" });
            DropIndex("dbo.EstabelecimentoVoto", new[] { "Estabelecimento_IdEstabelecimento" });
            DropIndex("dbo.EstabelecimentoComentario", new[] { "Usuaio_Id" });
            DropIndex("dbo.EstabelecimentoComentario", new[] { "Estabelecimento_IdEstabelecimento" });
            DropIndex("dbo.UsuarioClaim", new[] { "Usuario_Id" });
            DropIndex("dbo.ProdutoComentario", new[] { "Usuario_Id" });
            DropIndex("dbo.ProdutoComentario", new[] { "Produto_IdProduto" });
            DropIndex("dbo.Produto", new[] { "TipoProduto_IdTipoProduto" });
            DropTable("dbo.Estabelecimento_Produto");
            DropTable("dbo.Perfil");
            DropTable("dbo.TipoProduto");
            DropTable("dbo.Promocao");
            DropTable("dbo.UsuarioPerfil");
            DropTable("dbo.ProdutoVoto");
            DropTable("dbo.PreviousPassword");
            DropTable("dbo.UsuarioLogin");
            DropTable("dbo.EstabelecimentoVoto");
            DropTable("dbo.EstabelecimentoComentario");
            DropTable("dbo.UsuarioClaim");
            DropTable("dbo.Usuario");
            DropTable("dbo.ProdutoComentario");
            DropTable("dbo.Produto");
            DropTable("dbo.Estabelecimento");
        }
    }
}
