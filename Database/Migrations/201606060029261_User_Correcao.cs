namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Correcao : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.IdentityUserClaim", name: "IdentityUser_Id", newName: "Usuario_Id");
            RenameColumn(table: "dbo.IdentityUserLogin", name: "IdentityUser_Id", newName: "Usuario_Id");
            RenameColumn(table: "dbo.IdentityUserRole", name: "IdentityUser_Id", newName: "Usuario_Id");
            RenameIndex(table: "dbo.IdentityUserClaim", name: "IX_IdentityUser_Id", newName: "IX_Usuario_Id");
            RenameIndex(table: "dbo.IdentityUserLogin", name: "IX_IdentityUser_Id", newName: "IX_Usuario_Id");
            RenameIndex(table: "dbo.IdentityUserRole", name: "IX_IdentityUser_Id", newName: "IX_Usuario_Id");
            DropColumn("dbo.Usuario", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameIndex(table: "dbo.IdentityUserRole", name: "IX_Usuario_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.IdentityUserLogin", name: "IX_Usuario_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaim", name: "IX_Usuario_Id", newName: "IX_IdentityUser_Id");
            RenameColumn(table: "dbo.IdentityUserRole", name: "Usuario_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogin", name: "Usuario_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.IdentityUserClaim", name: "Usuario_Id", newName: "IdentityUser_Id");
        }
    }
}
